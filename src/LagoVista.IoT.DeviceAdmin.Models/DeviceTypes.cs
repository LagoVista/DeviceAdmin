using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.DeviceType_Title, DeviceLibraryResources.Names.DeviceType_Help,
        DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources),
        SaveUrl: "/api/devicetype", GetUrl: "/api/devicetype/{id}", GetListUrl: "/api/devicetypes", FactoryUrl: "/api/devicetype/factory", DeleteUrl: "/api/devicetype/{id}")]
    public class DeviceType : KeyOwnedDeviceAdminBase, IValidateable, INoSQLEntity, IOwnedEntity, IFormDescriptor
    {
        public DeviceType()
        {
            BillOfMaterial = new List<SectionGrouping<BOMItem>>();
            Resources = new List<EntityHeader>();
            AssociatedEquipment = new List<EquipmentSummary>();
        }

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Manufacturer, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacturer { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_ModelNumber, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string ModelNumber { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration, HelpResource: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Help, IsRequired:true,
            WaterMark: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader DefaultDeviceConfiguration { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_BillOfMaterial, WaterMark: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<SectionGrouping<BOMItem>> BillOfMaterial { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Resources, WaterMark: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<EntityHeader> Resources { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_AssociatedTools, WaterMark: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<EquipmentSummary> AssociatedEquipment { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Firmware, WaterMark: DeviceLibraryResources.Names.DeviceType_FirmwareSelect, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader Firmware { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Firmware_Revision, WaterMark: DeviceLibraryResources.Names.DeviceType_Firmware_RevisionSelect, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader FirmwareRevision { get; set; }

        public DeviceTypeSummary CreateSummary()
        {
            var summary = new DeviceTypeSummary()
            {
                Description = Description,
                Name = Name,
                Id = Id,
                Key = Key,
                Manufacturer = Manufacturer,
                ModelNumber = ModelNumber,
            };

            if (DefaultDeviceConfiguration != null && !DefaultDeviceConfiguration.IsEmpty())
            {
                summary.DefaultDeviceConfigId = DefaultDeviceConfiguration.Id;
                summary.DefaultDeviceConfigName = DefaultDeviceConfiguration.Text;
            }

            return summary;
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(DeviceType.Name),
                nameof(DeviceType.Key),
                nameof(DeviceType.ModelNumber),
                nameof(DeviceType.Firmware),
                nameof(DeviceType.FirmwareRevision),
                nameof(DeviceType.DefaultDeviceConfiguration),
                nameof(DeviceType.Manufacturer),
                nameof(DeviceType.Description),
                nameof(DeviceType.Resources),
                nameof(DeviceType.BillOfMaterial),
                nameof(DeviceType.AssociatedEquipment),
            };
        }
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.DeviceType_Title, DeviceLibraryResources.Names.DeviceType_Help,
      DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources),
      SaveUrl: "/api/devicetype", GetUrl: "/api/devicetype/{id}", GetListUrl: "/api/devicetypes", FactoryUrl: "/api/devicetype/factory", DeleteUrl: "/api/devicetype/{id}")]
    public class DeviceTypeSummary : SummaryData
    {
        public String DefaultDeviceConfigId { get; set; }
        public String DefaultDeviceConfigName { get; set; }

        public string ModelNumber { get; set; }
        public string Manufacturer { get; set; }
    }
}
