using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.DeviceBOMItem_Title,
        DeviceLibraryResources.Names.DeviceBOMItem_Help, DeviceLibraryResources.Names.DeviceBOMItem_Description,
                  EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class BOMItem
    {
        public BOMItem()
        {
            Resources = new List<EntityHeader>();
        }

        public string Id { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_PartNumber, FieldType: FieldTypes.Text, IsRequired:true, ResourceType: typeof(DeviceLibraryResources))]
        public string PartNumber { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Common_Name, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string Name { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Manufacturer, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacturer { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_AssemblyNumber, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string AssemblyNumber { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Quantity, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int Quantity { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Quantity, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Link { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Picture, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public List<EntityHeader> Resources { get; set; }
    }
}
