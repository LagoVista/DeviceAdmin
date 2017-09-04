using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.CustomField_Title, Resources.DeviceLibraryResources.Names.CustomFIeld_Help, Resources.DeviceLibraryResources.Names.CustomField_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class CustomField : IKeyedEntity, IFormDescriptor
    {
        public enum CustomFieldTypes
        {
            [EnumLabel("string", DeviceLibraryResources.Names.CustomField_FieldType_String, typeof(DeviceLibraryResources))]
            String,
            [EnumLabel("integer", DeviceLibraryResources.Names.CustomField_FieldType_Integer, typeof(DeviceLibraryResources))]
            Integer,
            [EnumLabel("decimal", DeviceLibraryResources.Names.CustomField_FieldType_Decimal, typeof(DeviceLibraryResources))]
            Decimal,
            [EnumLabel("email", DeviceLibraryResources.Names.CustomField_FieldType_IPAddress, typeof(DeviceLibraryResources))]
            Email,
            [EnumLabel("key", DeviceLibraryResources.Names.CustomField_FieldType_Key, typeof(DeviceLibraryResources))]
            Key,
            [EnumLabel("password", DeviceLibraryResources.Names.CustomField_FieldType_Password, typeof(DeviceLibraryResources))]
            Password,
            [EnumLabel("ipaddress", DeviceLibraryResources.Names.CustomField_FieldType_IPAddress, typeof(DeviceLibraryResources))]
            PAddress,
            [EnumLabel("website", DeviceLibraryResources.Names.CustomField_FieldType_WebSite, typeof(DeviceLibraryResources))]
            WebSite,
            [EnumLabel("date", DeviceLibraryResources.Names.CustomField_FieldType_Date, typeof(DeviceLibraryResources))]
            Date,
            [EnumLabel("datetime", DeviceLibraryResources.Names.CustomField_FIeldType_DateTime, typeof(DeviceLibraryResources))]
            DateTime,
            [EnumLabel("time", DeviceLibraryResources.Names.CustomField_FieldType_Time, typeof(DeviceLibraryResources))]
            Time
        }

        [JsonProperty("id")]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_Label,  IsRequired:true, FieldType:FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public String Label { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_IsRequired, FieldType:FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_IsReadOnly, HelpResource:Resources.DeviceLibraryResources.Names.CustomField_IsReadOnly_Help, FieldType:FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsReadOnly{ get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_FieldType, ResourceType: typeof(DeviceLibraryResources))]
        public CustomFieldTypes FieldType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, ValidationRegEx: Constants.KeyRegEx, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomFields_DefaultValue, FieldType: FieldTypes.Text, HelpResource: DeviceLibraryResources.Names.CustomFields_DefaultValue_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String DefaultValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_RegEx, HelpResource: Resources.DeviceLibraryResources.Names.CustomField_RegEx_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public String RegEx { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_HelpText, HelpResource: Resources.DeviceLibraryResources.Names.CusotmField_HelpText_Help, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string HelpText { get; set; }

        /// <summary>
        /// This will likely be a good candiate to reorder the list
        /// </summary>
        public int Order { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(CustomField.Label),
                nameof(CustomField.IsRequired),
                nameof(CustomField.IsReadOnly),
                nameof(CustomField.FieldType),
                nameof(CustomField.Key),
                nameof(CustomField.DefaultValue),
                nameof(CustomField.RegEx),
                nameof(CustomField.HelpText),
            };
        }
    }
}
