using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.MediaServices.Models;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.DeviceType_Title, DeviceLibraryResources.Names.DeviceType_Help,
        DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-device-model",
        SaveUrl: "/api/devicetype", GetUrl: "/api/devicetype/{id}", GetListUrl: "/api/devicetypes", FactoryUrl: "/api/devicetype/factory", DeleteUrl: "/api/devicetype/{id}")]
    public class DeviceType : IoTModelBase, IValidateable, IFormDescriptor, IFormDescriptorAdvanced, IFormDescriptorBottom, IFormDescriptorAdvancedCol2, IIconEntity, ISummaryFactory
    {
        public DeviceType()
        {
            Id = Guid.NewGuid().ToId();
            BillOfMaterial = new List<SectionGrouping<BOMItem>>();
            Resources = new List<MediaResourceSummary>();
            Equipment = new List<EntityHeader>();
            Icon = "icon-ae-device-model";
        }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Manufacturer, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacturer { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_ModelNumber, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string ModelNumber { get; set; }

        [FKeyProperty("DeviceConfiguration", "DeviceConfiguration.Id = {0}", "")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration,
            HelpResource: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Help, IsRequired: true, EntityHeaderPickerUrl: "/api/deviceconfigs",
            WaterMark: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader DefaultDeviceConfiguration { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_BillOfMaterial, WaterMark: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select,
            FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<SectionGrouping<BOMItem>> BillOfMaterial { get; set; }

        [FKeyProperty("MediaResource", "Resources[*].Id = {0}", "")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Resources, WaterMark: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select,
            FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<MediaResourceSummary> Resources { get; set; }

        [FKeyProperty(nameof(Equipment), "AssociatedEquipment[*].Id = {0}")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_AssociatedTools, FieldType: FieldTypes.ChildListInlinePicker, EntityHeaderPickerUrl: "/api/equipmentitems", ResourceType: typeof(DeviceLibraryResources))]
        public List<EntityHeader> Equipment { get; set; }

        [FKeyProperty("Firmware", "Firmware.Id = {0}", "")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Firmware, WaterMark: DeviceLibraryResources.Names.DeviceType_FirmwareSelect, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader Firmware { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(DeviceLibraryResources))]
        public string Icon { get; set; }

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

        public List<string> GetAdvancedFields()
        {
            return new List<string>()
            {
                nameof(DeviceType.Name),
                nameof(DeviceType.Key),
                nameof(DeviceType.Icon),
                nameof(DeviceType.DefaultDeviceConfiguration),
                nameof(DeviceType.Manufacturer),
                nameof(DeviceType.ModelNumber),
               };
        }

        public List<string> GetAdvancedFieldsCol2()
        {
            return new List<string>()
            {  
                nameof(DeviceType.Firmware),
                nameof(DeviceType.FirmwareRevision),
                nameof(DeviceType.Resources),
                nameof(DeviceType.BillOfMaterial),
                nameof(DeviceType.Equipment),
            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(DeviceType.Name),
                nameof(DeviceType.Key),
                nameof(DeviceType.Icon),
                nameof(DeviceType.DefaultDeviceConfiguration),
                nameof(DeviceType.Manufacturer),
                nameof(DeviceType.ModelNumber),
            };
        }

        public List<string> GetFormFieldsBottom()
        {
            return new List<string>()
            {
                nameof(Description)
            };
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.DeviceTypes_Title, DeviceLibraryResources.Names.DeviceType_Help,
      DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.Summary, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-device-model",
      SaveUrl: "/api/devicetype", GetUrl: "/api/devicetype/{id}", GetListUrl: "/api/devicetypes", FactoryUrl: "/api/devicetype/factory", DeleteUrl: "/api/devicetype/{id}")]
    public class DeviceTypeSummary : SummaryData
    {
        public String DefaultDeviceConfigId { get; set; }
        public String DefaultDeviceConfigName { get; set; }

        public string ModelNumber { get; set; }
        public string Manufacturer { get; set; }
    }
}
