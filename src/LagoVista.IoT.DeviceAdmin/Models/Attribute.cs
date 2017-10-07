using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Attribute_Title, DeviceLibraryResources.Names.Attribute_Description, DeviceLibraryResources.Names.Attribute_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class Attribute : NodeBase, IValidateable, IFormDescriptor
    {
        public Attribute()
        {

        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType, EnumType: (typeof(ParameterTypes)), HelpResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType_Help, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources), WaterMark: Resources.DeviceLibraryResources.Names.Attribute_AttributeType_Select, IsRequired: true, IsUserEditable: true)]
        public EntityHeader<ParameterTypes> AttributeType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript, WaterMark: Resources.DeviceLibraryResources.Names.Attribute_Script_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public String OnSetScript { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_ReadOnly, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_ReadOnly_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool ReadOnly { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<UnitSet> UnitSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_States, FieldType: FieldTypes.EntityHeaderPicker, WaterMark: Resources.DeviceLibraryResources.Names.Atttribute_StateSet_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_States_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<StateSet> StateSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_DefaultValue, FieldType: FieldTypes.Text,  ResourceType: typeof(DeviceLibraryResources))]
        public string DefaultValue { get; set; }

        public override string NodeType => NodeType_Attribute;

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Attribute.Name),
                nameof(Attribute.Key),
                nameof(Attribute.Description),
                nameof(Attribute.AttributeType),
                nameof(Attribute.ReadOnly),
                nameof(Attribute.UnitSet),
                nameof(Attribute.StateSet),
                nameof(Attribute.OnSetScript),
            };
        }

        public void Validate(DeviceWorkflow workflow, ValidationResult result)
        {
            /* If core attributes (validated at parent level) are not valid, don't bother validating */
            if (Validator.Validate(this).Successful)
            {
                result.Concat(ValidateNodeBase(workflow));
                if (EntityHeader.IsNullOrEmpty(AttributeType))
                {
                    result.Errors.Add(new ErrorMessage($"On Attribute {Name}, Attribute Type is missing.", true));
                }
                else if (AttributeType.Value == ParameterTypes.ValueWithUnit)
                {
                    StateSet = null;
                    if (EntityHeader.IsNullOrEmpty(UnitSet))
                    {
                        result.Errors.Add(new ErrorMessage($"On Attribute {Name}, Value with Unit is data type, but no Unit Set was provided.", true));
                        return;
                    }
                }
                else if (AttributeType.Value == ParameterTypes.State)
                {
                    UnitSet = null;
                    if (EntityHeader.IsNullOrEmpty(StateSet))
                    {
                        result.Errors.Add(new ErrorMessage($"On Attribute {Name}, State Set is data type, but no State Set was provided.", true));
                        return;
                    }
                }
                else
                {
                    StateSet = null;
                    UnitSet = null;
                }

                if (!result.Successful)
                {
                    return;
                }

                foreach (var connection in OutgoingConnections)
                {
                    switch (connection.NodeType)
                    {
                        case NodeType_Input:
                        case NodeType_InputCommand:
                            result.Errors.Add(new ErrorMessage($"Mapping from an Input to a node of type: {NodeType} is not supported", true));
                            break;
                        case NodeType_StateMachine: ValidateStateMachine(result, workflow, connection); break;
                        case NodeType_Attribute:
                        case NodeType_OutputCommand:
                            break;
                    }
                }
            }
        }
    }
}
