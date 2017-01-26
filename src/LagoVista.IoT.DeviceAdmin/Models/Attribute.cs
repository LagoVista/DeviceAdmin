using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Attribute_Title, DeviceLibraryResources.Names.Attribute_Description, DeviceLibraryResources.Names.Attribute_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
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
            [EnumLabel("statemachine", DeviceLibraryResources.Names.Attribute_StateMachine, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_StateMachine_Help)]
            StateMachine,
            [EnumLabel("discrete", DeviceLibraryResources.Names.Attribute_Discrete, typeof(DeviceLibraryResources), DeviceLibraryResources.Names.Attribute_Discrete_Help)]
            Discrete
        }

        public enum AttributeDirections
        {
            [EnumLabel("input", DeviceLibraryResources.Names.Attribute_Direction_Input, typeof(DeviceLibraryResources))]
            Input,
            [EnumLabel("output", DeviceLibraryResources.Names.Attribute_Direction_Output, typeof(DeviceLibraryResources))]
            Output,
            [EnumLabel("inputandoutput", DeviceLibraryResources.Names.Attribute_Direction_InputAndOutput, typeof(DeviceLibraryResources))]
            InputAndOutput
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_Direction, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_Direction_Help, FieldType: FieldTypes.OptionsList, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public AttributeDirections Direction { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_AttributeType_Help, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public EntityHeader AttributeType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_SetScript_Help, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public String Script { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_Shared, HelpResource: Resources.DeviceLibraryResources.Names.Action_Standard_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader SharedAttribute { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.AttributeUnit_Help, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_UnitSet_Help, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<AttributeUnitSet> Units { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Attribute_StateMachine, HelpResource: Resources.DeviceLibraryResources.Names.Attribute_StateMachine_Help, ResourceType: typeof(DeviceLibraryResources))]
        public StateMachine StateMachine { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Notes, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<AdminNote> Notes { get; set; }

        public Point DiagramLocation { get; set; }

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
