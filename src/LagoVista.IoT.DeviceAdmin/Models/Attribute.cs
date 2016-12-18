using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Name:"Attribute", Domain:DeviceAdminDomain.DeviceAdmin, Description:"Attributes are meta-data that are attached to a device configuration that are used to maintain the state of the device.  Attributes can be one of the following, a simple value with a unit, a standard attribute that is common across many device configurations or a state machine.")]
    public class Attribute : DeviceModelBase, IKeyedEntity, INamedEntity, IIDEntity, IAuditableEntity, IValidateable, IOwnedEntity
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        public enum AttributeTypes
        {
            [EnumLabel(LabelResource:DeviceLibraryResources.Names.Attribute_StateMachine, ResourceType: typeof(DeviceLibraryResources))]
            StateMachine,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.Attribute_Standard, ResourceType: typeof(DeviceLibraryResources))]
            StandardAttribute,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.Attribute_Simple, ResourceType: typeof(DeviceLibraryResources))]
            Simple
        }

        public enum AttributeDirections
        {
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.Attribute_Direction_Input, ResourceType: typeof(DeviceLibraryResources))]
            Input,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.Attribute_Direction_Output, ResourceType: typeof(DeviceLibraryResources))]
            Output,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.Attribute_Direction_InputAndOutput, ResourceType: typeof(DeviceLibraryResources))]
            InputAndOutput
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_Direction, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_Direction_Help, FieldType: FieldTypes.OptionsList, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public AttributeDirections Direction { get; set; }



        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_Standard, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_StandardAttribute_Help,  ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader StandardAttribute { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_Simple, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public IEnumerable<AttributeUnitSet> Units { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_StateMachine, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_StateMachine_Help, ResourceType: typeof(DeviceLibraryResources))]
        public StateMachine StateMachine { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Notes, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help,  ResourceType: typeof(DeviceLibraryResources))]
        public IEnumerable<AdminNote> Notes { get; set; }

        public AttributeSummary CreateSummary()
        {
            return new Models.AttributeSummary()
            {
                Id = Id,
                Name = Name,
                Key = Key,
                IsPublic = IsPublic,

            };
        }
    }

    public class AttributeSummary : IKeyedEntity, INamedEntity, IIDEntity
    {
        public String Id { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Name { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }

        public String AttributeType { get; set; }
    }
}
