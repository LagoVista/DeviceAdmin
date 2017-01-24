using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.ActionParameter_Title, DeviceLibraryResources.Names.ActionParameter_Description, DeviceLibraryResources.Names.ActionParameter_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class ActionParameter : INamedEntity, IKeyedEntity
    {
        [JsonProperty("id")]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        public enum ParameterTypes
        {
            [EnumLabel("String", DeviceLibraryResources.Names.Action_Parameter_Types_String, typeof(DeviceLibraryResources))]
            String,
            [EnumLabel("Integer", DeviceLibraryResources.Names.Action_Parameter_Types_Integer, typeof(DeviceLibraryResources))]
            Integer,
            [EnumLabel("Decimal", DeviceLibraryResources.Names.Action_Parameter_Types_Decimal,  typeof(DeviceLibraryResources))]
            Decimal,
            [EnumLabel("TrueFalse", DeviceLibraryResources.Names.Action_Parameter_Tyeps_TrueFalse, typeof(DeviceLibraryResources))]
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
