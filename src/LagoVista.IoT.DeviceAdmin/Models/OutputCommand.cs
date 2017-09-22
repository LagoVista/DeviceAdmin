using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using LagoVista.Core.Models;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.OutputCommand_Title, DeviceLibraryResources.Names.OutputCommand_Description, DeviceLibraryResources.Names.OutputCommand_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class OutputCommand : NodeBase, IValidateable
    {
        public OutputCommand()
        {
            Parameters = new ObservableCollection<Parameter>();
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.OutputCommand_Script, HelpResource: Resources.DeviceLibraryResources.Names.OutputCommand_Script_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public string OnExecuteScript { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.InputCommand_Parameters, HelpResource: Resources.DeviceLibraryResources.Names.Parameter_Help, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<Parameter> Parameters { get; set; }

        public override string NodeType => NodeType_OutputCommand;

        public ValidationResult Validate(DeviceWorkflow workflow)
        {
            var result = Validator.Validate(this);
            result.Concat(ValidateNodeBase(workflow));
            if (result.Successful)
            {
                if (Parameters.Select(param => param.Key).Count() != Parameters.Count())
                {
                    result.Errors.Add(new ErrorMessage($"Keys on Parameters for Output Commands must be unique.", true));
                    return result;
                }

                foreach (var parameter in Parameters)
                {

                    if (parameter.ParameterType == null)
                    {
                        result.Errors.Add(new ErrorMessage($"On Output Command {Name}, Parameter {parameter.Name} parameter type is missing.", true));
                    }
                    else if (parameter.ParameterType.Value == ParameterTypes.ValueWithUnit)
                    {
                        parameter.StateSet = null;
                        if (EntityHeader.IsNullOrEmpty(parameter.UnitSet))
                        {
                            result.Errors.Add(new ErrorMessage($"On Output Command {Name}, Parameter {parameter.Name} Value with Unit is data type, but no unit type was provided.", true));
                            return result;
                        }
                    }
                    else if (parameter.ParameterType.Value == ParameterTypes.State)
                    {
                        parameter.UnitSet = null;
                        if (EntityHeader.IsNullOrEmpty(parameter.StateSet))
                        {
                            result.Errors.Add(new ErrorMessage($"On Output Command {Name}, Parameter {parameter.Name} is a state set, but no state set was provided.", true));
                            return result;
                        }
                    }
                    else
                    {
                        parameter.UnitSet = null;
                        parameter.StateSet = null;
                    }
                }

                if(OutgoingConnections.Count > 0)
                {
                    result.Errors.Add(new ErrorMessage($"Mapping from an Output Command to an other node types is not supported", true));
                }
            }

            return result;
        }
    }
}
