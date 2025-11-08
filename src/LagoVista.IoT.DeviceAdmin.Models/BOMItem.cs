// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 5f4dbc0654fcdb0d920cf15c301fe73d8a63e510d2fe5b7228702e1c2b5a4fb6
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.MediaServices.Models;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.DeviceBOMItem_Title,
        DeviceLibraryResources.Names.DeviceBOMItem_Help, DeviceLibraryResources.Names.DeviceBOMItem_Description,
        EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources),
        FactoryUrl: "/api/devicetype/bomitem/factory")]
    public class BOMItem
    {
        public BOMItem()
        {
            Resources = new List<MediaResourceSummary>();
        }

        public string Id { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_PartNumber, FieldType: FieldTypes.Text, IsRequired:true, ResourceType: typeof(DeviceLibraryResources))]
        public string PartNumber { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Common_Name, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string Name { get; set; }
        
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_IsPartsKit, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]        
        public bool IsPartsKit { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Manufacturer, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacturer { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_AssemblyNumber, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string AssemblyNumber { get; set; }
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Quantity, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int Quantity { get; set; }
        
        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Quantity, FieldType: FieldTypes.WebLink, ResourceType: typeof(DeviceLibraryResources))]
        public string Link { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Cost, FieldType: FieldTypes.Decimal, ResourceType: typeof(DeviceLibraryResources))]
        public string Cost { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Picture, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public List<MediaResourceSummary> Resources { get; set; }
    }
}
