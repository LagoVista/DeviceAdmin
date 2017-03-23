using LagoVista.Core.Attributes;
using LagoVista.IoT.DeviceAdmin.Resources;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.Page_Title, Resources.DeviceLibraryResources.Names.Page_Help, Resources.DeviceLibraryResources.Names.Page_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class Page
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Page_Name, ResourceType: typeof(DeviceLibraryResources))]
        public string Name { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Page_PageNumber, ResourceType: typeof(DeviceLibraryResources))]
        public int PageNumber { get; set; }
    }
}
