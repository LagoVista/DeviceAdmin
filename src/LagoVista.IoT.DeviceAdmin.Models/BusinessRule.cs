// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 7a87c19871c6b852760a97042d2c326788c99daba7306a3438817601b21c5a10
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.BusinessRule_Title, Resources.DeviceLibraryResources.Names.BusinessRule_Help,
        Resources.DeviceLibraryResources.Names.BusinessRule_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources),
        FactoryUrl: "/api/deviceadmin/factory/devicebusinessrule")]
    public class BusinessRule : IFormDescriptor
    {
        public BusinessRule()
        {
            IsEnabled = true;
            Id = Guid.NewGuid().ToId();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [CloneOptions(false)]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public string Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public string Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.BusinessRule_IsEnabled, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsEnabled { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.BusinessRule_IsBeta, HelpResource: Resources.DeviceLibraryResources.Names.BusinessRule_IsBeta_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsBeta { get; set; }


        [CloneOptions(false)]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.BusinessRule_ServiceTicket, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/fslite/tickets/templates",
            WaterMark: Resources.DeviceLibraryResources.Names.BusinessRule_ServiceTicket_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.BusinessRule_ServiceTicket_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader ServiceTicketTemplate { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.BusinessRule_ErrorCode, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/errorcodes", FactoryUrl: "/api/errorcode/factory",
            WaterMark: Resources.DeviceLibraryResources.Names.BusinessRule_ErrorCode_Watermark, HelpResource: Resources.DeviceLibraryResources.Names.BusinessRule_ErrorCode_Help, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader ErrorCode { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.BusinessRule_Script, WaterMark: Resources.DeviceLibraryResources.Names.BusinessRule_Script_Watermark,
            ScriptTemplateName:"businessRule",
            HelpResource: Resources.DeviceLibraryResources.Names.BusinessRule_Script_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public String Script { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
               nameof(Name),
               nameof(Key),
               nameof(Description),
               nameof(IsBeta),
               nameof(IsEnabled),
               nameof(ErrorCode),
               nameof(ServiceTicketTemplate),
               nameof(Script)
            };
        }
    }
}
