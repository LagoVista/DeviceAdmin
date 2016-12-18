using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Name:"Custom Field", Domain:DeviceAdminDomain.DeviceAdmin, Description:"Custom Fields can be used to extend Device Configuration.  It's not possible to know in advance what paramters each installation will require so these custom parameters can be defined when creating the device configration.  Then when a device is provisioned with the device configuration, those custom values can be populated.  Once they are added, they are first-class-citizens to be used in reports and scripts.")]
    public class CustomField : IKeyedEntity
    {
        public enum CustomFieldTypes
        {
            [EnumLabel(LabelResource:DeviceLibraryResources.Names.CustomField_FieldType_String, ResourceType: typeof(DeviceLibraryResources))]
            String,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FieldType_Integer, ResourceType: typeof(DeviceLibraryResources))]
            Integer,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FieldType_Decimal, ResourceType: typeof(DeviceLibraryResources))]
            Decimal,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FieldType_IPAddress, ResourceType: typeof(DeviceLibraryResources))]
            Email,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FieldType_Key, ResourceType: typeof(DeviceLibraryResources))]
            Key,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FieldType_Password, ResourceType: typeof(DeviceLibraryResources))]
            Password,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FieldType_IPAddress, ResourceType: typeof(DeviceLibraryResources))]
            IPAddress,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FieldType_WebSite, ResourceType: typeof(DeviceLibraryResources))]
            WebSite,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FieldType_Date, ResourceType: typeof(DeviceLibraryResources))]
            Date,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FIeldType_DateTime, ResourceType: typeof(DeviceLibraryResources))]
            DateTime,
            [EnumLabel(LabelResource: DeviceLibraryResources.Names.CustomField_FieldType_Time, ResourceType: typeof(DeviceLibraryResources))]
            Time
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_Label, ResourceType: typeof(DeviceLibraryResources))]
        public String Label { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_IsRequired, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsRequired { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_FieldType, ResourceType: typeof(DeviceLibraryResources))]
        public CustomFieldTypes FieldType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, ValidationRegEx: Constants.KeyRegEx, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help,  RegExValidationMessageResource:Resources.DeviceLibraryResources.Names.Common_Key_Validation, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomFields_DefaultValue, FieldType: FieldTypes.Text, HelpResource:DeviceLibraryResources.Names.CustomFields_DefaultValue_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String DefaultValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_RegEx, HelpResource: Resources.DeviceLibraryResources.Names.CustomField_RegEx_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public String RegEx { get; set; }

        /// <summary>
        /// This will likely be a good candiate to reorder the list
        /// </summary>
        public int Order { get; set; }
    }
}
