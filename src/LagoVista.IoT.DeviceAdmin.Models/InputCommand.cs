using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.InputCommand_Title, DeviceLibraryResources.Names.InputCommand_Parameters, DeviceLibraryResources.Names.InputCommand_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class InputCommand : NodeBase, IValidateable, IFormDescriptor
    {
        public InputCommand()
        {
            Parameters = new ObservableCollection<Parameter>();
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
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_Parameters, HelpResource: Resources.DeviceLibraryResources.Names.Parameter_Help, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<Parameter> Parameters { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_Script, HelpResource: Resources.DeviceLibraryResources.Names.InputCommand_Script_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public String OnArriveScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointType, HelpResource: Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_Help, WaterMark: Resources.DeviceLibraryResources.Names.InputCommand_EndpointType_Watermark, FieldType: FieldTypes.Picker, EnumType: typeof(EndpointTypes), ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public EntityHeader<EndpointTypes> EndpointType { get; set; }

        public override string NodeType => NodeType_InputCommand;

        public ValidationResult Validate(DeviceWorkflow workflow, ValidationResult result)
        {
            if (Validator.Validate(this).Successful)
            {
                result.Concat(ValidateNodeBase(workflow));
                if (Parameters.Select(param => param.Key).Distinct().Count() != Parameters.Count())
                {
                    result.Errors.Add(new ErrorMessage($"On Input Command, {Name} keys on Parameters must be unique.", true));
                    return result;
                }

                foreach (var parameter in Parameters)
                {
                    if (EntityHeader.IsNullOrEmpty(parameter.ParameterLocation))
                    {
                        result.Errors.Add(new ErrorMessage($"On Input Command {Name}, Parameter Location is not provided.", true));
                        return result;
                    }

                    if (parameter.ParameterType == null)
                    {
                        result.Errors.Add(new ErrorMessage($"On Input Command {Name}, Parameter {parameter.Name} parameter type is missing.", true));
                    }
                    else if (parameter.ParameterType.Value == ParameterTypes.ValueWithUnit)
                    {
                        parameter.StateSet = null;
                        if (EntityHeader.IsNullOrEmpty(parameter.UnitSet))
                        {
                            result.Errors.Add(new ErrorMessage($"On Input Command {Name}, Parameter {parameter.Name} Value with Unit is data type, but no unit type was provided.", true));
                            return result;
                        }
                    }
                    else if (parameter.ParameterType.Value == ParameterTypes.State)
                    {
                        parameter.UnitSet = null;
                        if (EntityHeader.IsNullOrEmpty(parameter.StateSet))
                        {
                            result.Errors.Add(new ErrorMessage($"On Input Command {Name}, Parameter {parameter.Name} is a state set, but no state set was provided.", true));
                            return result;
                        }
                    }
                    else
                    {
                        parameter.UnitSet = null;
                        parameter.StateSet = null;
                    }

                    if (parameter.ParameterLocation.Value == PayloadTypes.Json && (EndpointType.Value == EndpointTypes.RestGet || EndpointType.Value == EndpointTypes.RestDelete))
                    {
                        result.AddSystemError("End point type of GET or DELETE was specified, however at least one of the parameters has JSON specified for the parameter location.");
                    }
                }

                if(!result.Successful)
                {
                    return result;
                }

                foreach (var connection in OutgoingConnections)
                {
                    switch (connection.NodeType)
                    {
                        case NodeType_Input:
                        case NodeType_InputCommand:
                            result.Errors.Add(new ErrorMessage($"Mapping from an Input Command on node {Name} to a node of type {connection.NodeType} is not supported", true));
                            break;
                        case NodeType_Attribute:
                            if (connection.InputCommandKey == null)
                            {
                                result.Errors.Add(new ErrorMessage($"When Mapping from in Input Command on node {Name} to an Attribute, you must specify which parameter will be mapped", false));
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

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(InputCommand.Name),
                nameof(InputCommand.Key),
                nameof(InputCommand.EndpointType),
                nameof(InputCommand.OnArriveScript),
                nameof(InputCommand.Description),
            };
        }
    }
}
