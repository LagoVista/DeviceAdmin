using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using LagoVista.IoT.DeviceAdmin.Models.Resources;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.WorkflowInput_Title, DeviceLibraryResources.Names.WorkflowInput_Description, DeviceLibraryResources.Names.WorkflowInput_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class WorkflowInput : NodeBase, IValidateable, IFormDescriptor
    {
        public WorkflowInput()
        {
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Type, WaterMark: DeviceLibraryResources.Names.WorkflowInput_Type_Watermark, EnumType: typeof(ParameterTypes), HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Type_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public EntityHeader<ParameterTypes> InputType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_SetScript, WaterMark: Resources.DeviceLibraryResources.Names.WorkflowInput_Script_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_SetScript_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public String OnSetScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Units, WaterMark: Resources.DeviceLibraryResources.Names.WorkflowInput_UnitSet_Watermark, FieldType: FieldTypes.EntityHeaderPicker, HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_Units_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.WorkflowInput_States, WaterMark: Resources.DeviceLibraryResources.Names.WorkflowInput_StateSet_Watermark, FieldType: FieldTypes.EntityHeaderPicker, HelpResource: Resources.DeviceLibraryResources.Names.WorkflowInput_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }

        public override string NodeType => NodeType_Input;

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(WorkflowInput.Name),
                nameof(WorkflowInput.Key),
                nameof(WorkflowInput.Description),
                nameof(WorkflowInput.InputType),
                nameof(WorkflowInput.Description),
                nameof(WorkflowInput.StateSet),
                nameof(WorkflowInput.UnitSet),
                nameof(WorkflowInput.OnSetScript),
            };
        }

        public void Validate(DeviceWorkflow workflow, ValidationResult result)
        {
            /* If core attributes (validated at parent level) are not valid, don't bother validating */
            if (Validator.Validate(this).Successful)
            {
                result.Concat(ValidateNodeBase(workflow));
                if (EntityHeader.IsNullOrEmpty(InputType))
                {
                    result.Errors.Add(new ErrorMessage($"On Workflow Input {Name}, Input Type is missing.", true));
                }
                else if (InputType.Value == ParameterTypes.ValueWithUnit)
                {
                    StateSet = null;
                    if (EntityHeader.IsNullOrEmpty(UnitSet))
                    {
                        result.Errors.Add(new ErrorMessage($"On Workflow Input {Name}, data type is Value with Unit, but no unit type was provided.", true));
                        return;
                    }
                }
                else if (InputType.Value == ParameterTypes.State)
                {
                    UnitSet = null;
                    if (EntityHeader.IsNullOrEmpty(StateSet))
                    {
                        result.Errors.Add(new ErrorMessage($"On Workflow Input {Name}, data type is a State Set, but no state set was provided.", true));
                        return ;
                    }
                }
                else
                {
                    UnitSet = null;
                    StateSet = null;
                }

                if(!result.Successful)
                {
                    return ;
                }

                /* If we made it here, we can assume that all nodes have been validated that they exist and they are part of the workflow */
                foreach (var connection in OutgoingConnections)
                {
                    switch (connection.NodeType)
                    {
                        case NodeType_Input:
                        case NodeType_InputCommand:
                            result.Errors.Add(new ErrorMessage($"Mapping from an Input to a node of type {connection.NodeType} is not supported", true));
                            break;
                        case NodeType_Attribute:
                            var attribute = workflow.Attributes.Where(stm => stm.Key == connection.NodeKey).First();
                            if (attribute.AttributeType.Value != InputType.Value)
                            {
                                result.Errors.Add(new ErrorMessage($"Invalid Mapping between {Name} and {connection.NodeName} - Source Type {InputType.Text} - Destination Type: {attribute.AttributeType.Text}."));
                            }
                            else
                            {
                                if (attribute.AttributeType.Value == ParameterTypes.State &&
                                   attribute.StateSet.Id != StateSet.Id)
                                {
                                    result.Errors.Add(new ErrorMessage($"Invalid Mapping between {Name} and {connection.NodeName} - State Sets to do not match."));
                                }
                                else if (attribute.AttributeType.Value == ParameterTypes.ValueWithUnit &&
                                     attribute.UnitSet.Id != UnitSet.Id)
                                {
                                    result.Errors.Add(new ErrorMessage($"Invalid Mapping between {Name} and {connection.NodeName} - Unit Sets to do not match."));
                                }
                            }

                            break;
                        case NodeType_OutputCommand:
                            break;
                        case NodeType_StateMachine:
                            if (EntityHeader.IsNullOrEmpty(connection.StateMachineEvent))
                            {
                                result.Errors.Add(new ErrorMessage($"Transition Event is empty from {Name} to State Machine {connection.NodeName}."));
                            }
                            else
                            {
                                var outputStateMachine = workflow.StateMachines.Where(stm => stm.Key == connection.NodeKey).First();
                                if (!outputStateMachine.Events.Where(evt => evt.Key == connection.StateMachineEvent.Id).Any()) result.Errors.Add(new ErrorMessage($"Transition Event {connection.StateMachineEvent.Text} from {Name} to {outputStateMachine.Name} does not exist on that state machine."));
                            }
                            break;
                    }
                }
            }
        }
    }
}
