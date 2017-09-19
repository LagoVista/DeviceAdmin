using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.InputCommand_Title, DeviceLibraryResources.Names.InputCommand_Parameters, DeviceLibraryResources.Names.InputCommand_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class InputCommand : NodeBase, IValidateable
    {
        public InputCommand()
        {
            Parameters = new ObservableCollection<Parameter>();
        }

        public enum PayloadTypes
        {
            [EnumLabel("json", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_JSON, typeof(Resources.DeviceLibraryResources))]
            Json,
            [EnumLabel("xml", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_XML, typeof(Resources.DeviceLibraryResources))]
            Xml,
            [EnumLabel("form", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_Form, typeof(Resources.DeviceLibraryResources))]
            Form,
            [EnumLabel("querystring", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_QueryString, typeof(Resources.DeviceLibraryResources))]
            QueryString,
            [EnumLabel("none", Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_None, typeof(Resources.DeviceLibraryResources))]
            None
        }

        public enum EndpointTypes
        {
            [EnumLabel("get", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Get, typeof(Resources.DeviceLibraryResources))]
            RestGet,
            [EnumLabel("post", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Post, typeof(Resources.DeviceLibraryResources))]
            RestPost,
            [EnumLabel("put", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Put, typeof(Resources.DeviceLibraryResources))]
            RestPut,
            [EnumLabel("delete", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Delete, typeof(Resources.DeviceLibraryResources))]
            RestDelete,
            [EnumLabel("internal", Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_REST_Get, typeof(Resources.DeviceLibraryResources), Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_Internal_Help)]
            Internal
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_Parameters, HelpResource: Resources.DeviceLibraryResources.Names.Parameter_Help, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<Parameter> Parameters { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_Script, HelpResource: Resources.DeviceLibraryResources.Names.InputCommand_Script_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public String OnArriveScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointType, HelpResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_Help, WaterMark:Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_Watermark, FieldType: FieldTypes.Picker, EnumType:typeof(EndpointTypes), ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public EntityHeader<EndpointTypes> EndpointType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload, HelpResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_Help, WaterMark: Resources.DeviceLibraryResources.Names.InputCommand_EndpointPayload_Watermark, FieldType: FieldTypes.Picker, EnumType:typeof(PayloadTypes), ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<PayloadTypes> EndpointPayloadType { get; set; }

        public override string NodeType => NodeType_InputCommand;


        public ValidationResult Validate(DeviceWorkflow workflow)
        {
            var result = Validator.Validate(this);
            result.Concat(ValidateNodeBase(workflow));
            if (result.Successful)
            {
                foreach (var parameter in Parameters)
                {
                    if (parameter.ParameterType.Value == ParameterTypes.ValueWithUnit && EntityHeader.IsNullOrEmpty(parameter.UnitSet))
                    {
                        result.Errors.Add(new ErrorMessage($"On Attribute {Name}, Parameter {parameter.Name} Value with Unit is data type, but no unit type was provided.", true));
                        return result;
                    }

                    if (parameter.ParameterType.Value == ParameterTypes.State && EntityHeader.IsNullOrEmpty(parameter.StateSet))
                    {
                        result.Errors.Add(new ErrorMessage($"On Input Command {Name}, Parameter {parameter.Name} is a state set, but no state set was provided.", true));
                        return result;
                    }
                }

                foreach (var connection in OutgoingConnections)
                {
                    switch (connection.NodeType)
                    {
                        case NodeType_Input:
                        case NodeType_InputCommand:
                            result.Errors.Add(new ErrorMessage($"Mapping from an Input Command to a node of type {NodeType} is not supported", true));
                            break;
                        case NodeType_Attribute:
                            if (connection.InputCommandKey == null)
                            {
                                result.Errors.Add(new ErrorMessage($"When Mapping from in Input Command to an Attribute, you must specify which parameter will be mapped", false));
                            }
                            else
                            {
                                var parameter = Parameters.Where(prm => prm.Key == connection.InputCommandKey).FirstOrDefault();
                                if (parameter == null)
                                {
                                    result.Errors.Add(new ErrorMessage($"Specified Mapping Key {connection.InputCommandKey} not found on inputs from {Name}", false));
                                }
                                else
                                {
                                    var attribute = workflow.Attributes.Where(attr => attr.Key == connection.NodeKey).First();
                                    if (attribute.AttributeType.Value != parameter.ParameterType.Value)
                                    {
                                        result.Errors.Add(new ErrorMessage($"On input command {Name}, type mismatch on mapping to {connection.NodeName} from input command {parameter.Name} to attribute of type {parameter.ParameterType.Text}.", false));
                                    }
                                    else
                                    {
                                        if (attribute.AttributeType.Value == ParameterTypes.State &&
                                       attribute.StateSet.Id != parameter.StateSet.Id)
                                        {
                                            result.Errors.Add(new ErrorMessage($"Invalid Mapping between {Name} and {connection.NodeName} - State Sets to do not match."));
                                        }
                                        else if (attribute.AttributeType.Value == ParameterTypes.ValueWithUnit &&
                                             attribute.UnitSet.Id != parameter.UnitSet.Id)
                                        {
                                            result.Errors.Add(new ErrorMessage($"Invalid Mapping between {Name} and {connection.NodeName} - Unit Sets to do not match."));
                                        }
                                    }
                                }
                            }

                            break;
                        case NodeType_StateMachine:
                            ValidateStateMachine(result, workflow, connection);
                            break;
                    }
                }
            }

            return result;

        }
    }
}
