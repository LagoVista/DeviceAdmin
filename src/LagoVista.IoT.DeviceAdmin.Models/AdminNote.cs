using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.AdminNote_Title, DeviceLibraryResources.Names.AdminNote_Description, DeviceLibraryResources.Names.AdminNote_Help, 
        EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources), FactoryUrl: "/api/deviceadmin/factory/adminnote")]
    public class AdminNote
    {
        [JsonProperty("id")]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_CreationDate, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String CreationDate { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_CreatedBy, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public EntityHeader CreatedBy { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_LastUpdated, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String LastUpdatedDate { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_LastUpdatedBy, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public EntityHeader LastUpdatedBy { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Note, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Note { get; set; }

        public AdminNote Clone()
        {
            return new AdminNote()
            {
                CreatedBy = CreatedBy.Clone(),
                CreationDate = CreationDate,
                Id = Id,
                LastUpdatedBy = LastUpdatedBy,
                LastUpdatedDate = LastUpdatedDate,
                Note = Note
            };
        }
    }
}
