using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Title: DeviceLibraryResources.Names.ActionParameter_Title, Domain: DeviceAdminDomain.DeviceAdmin, Description: DeviceLibraryResources.Names.ActionParameter_Description, UserHelp: DeviceLibraryResources.Names.ActionParameter_Help, ResourceType: typeof(DeviceLibraryResources))]
    public class ActionParameter : INamedEntity, IKeyedEntity
    {
        public enum ParameterTypes
        {
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.Action_Parameter_Types_String, ResourceType: typeof(DeviceLibraryResources))]
            String,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.Action_Parameter_Types_Integer, ResourceType: typeof(DeviceLibraryResources))]
            Integer,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.Action_Parameter_Types_Decimal, ResourceType: typeof(DeviceLibraryResources))]
            Decimal,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.Action_Parameter_Tyeps_TrueFalse, ResourceType: typeof(DeviceLibraryResources))]
            TrueFalse
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsRequired, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Name { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_Parameter_Types, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public ParameterTypes ParameterType { get; set; }
    }
}
