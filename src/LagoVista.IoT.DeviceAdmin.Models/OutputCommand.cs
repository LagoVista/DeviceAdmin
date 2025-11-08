// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 07d94c3956b95dbcc8e413cc2143c7a54dd616105707aa5cc28022e0de25e366
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Validation;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.Core.Interfaces;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.OutputCommand_Title, DeviceLibraryResources.Names.OutputCommand_Description, DeviceLibraryResources.Names.OutputCommand_Help, 
        EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources), FactoryUrl: "/api/deviceadmin/factory/outputcommand")]
    public class OutputCommand : NodeBase, IValidateable, IFormDescriptor
    {
        public OutputCommand()
        {
            Parameters = new ObservableCollection<Parameter>();
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.OutputCommand_Script, 
            HelpResource: Resources.DeviceLibraryResources.Names.OutputCommand_Script_Help,
            WaterMark: Resources.DeviceLibraryResources.Names.OutputCommand_Script_WaterMark,
            FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public string OnExecuteScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.OutputCommand_Parameters, 
            HelpResource: Resources.DeviceLibraryResources.Names.OutputCommand_Parameters_Help,
            FactoryUrl: "/api/deviceadmin/factory/parameter", FieldType: FieldTypes.ChildListInline,
            ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<Parameter> Parameters { get; set; }

        public override string NodeType => NodeType_OutputCommand;

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Description),
                nameof(OnExecuteScript),
                nameof(Parameters)
            };
        }

        public void Validate(DeviceWorkflow workflow, ValidationResult result)
        {
            if (result.Successful)
            {
                result.Concat(ValidateNodeBase(workflow));

                if (Parameters.Select(param => param.Key).Distinct().Count() != Parameters.Count())
                {
                    result.Errors.Add(new ErrorMessage($"On Output Command {Name}, keys on Parameters must be unique.", true));
                    return;
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
                            return;
                        }
                    }
                    else if (parameter.ParameterType.Value == ParameterTypes.State)
                    {
                        parameter.UnitSet = null;
                        if (EntityHeader.IsNullOrEmpty(parameter.StateSet))
                        {
                            result.Errors.Add(new ErrorMessage($"On Output Command {Name}, Parameter {parameter.Name} is a state set, but no state set was provided.", true));
                            return;
                        }
                    }
                    else
                    {
                        parameter.UnitSet = null;
                        parameter.StateSet = null;
                    }
                }

                if (OutgoingConnections.Count > 0)
                {
                    result.Errors.Add(new ErrorMessage($"Mapping from an Output Command to an other node types is not supported", true));
                }
            }
        }
    }
}
