using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Title: DeviceLibraryResources.Names.AdminNote_Title, Domain: DeviceAdminDomain.DeviceAdmin, Description: DeviceLibraryResources.Names.AdminNote_Description, UserHelp: DeviceLibraryResources.Names.AdminNote_Help, ResourceType: typeof(DeviceLibraryResources))]
    public class AdminNote
    {
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
    }
}
