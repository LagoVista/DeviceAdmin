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
        DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-device-model", Cloneable: true,
        SaveUrl: "/api/devicetype", GetUrl: "/api/devicetype/{id}", GetListUrl: "/api/devicetypes", FactoryUrl: "/api/devicetype/factory", DeleteUrl: "/api/devicetype/{id}",
        ListUIUrl: "/iotstudio/device/devicemodels", EditUIUrl: "/iotstudio/device/devicemodel/{id}", CreateUIUrl: "/iotstudio/device/devicemodel/add")]
    public class DeviceType : IoTModelBase, IValidateable, IFormDescriptor, IFormDescriptorAdvanced, IFormDescriptorBottom, IFormDescriptorAdvancedCol2, IIconEntity, ISummaryFactory, IIDEntity, ICategorized
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

        [FKeyProperty("DeviceConfiguration", WhereClause:"DeviceConfiguration.Id = {0}")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration,
            HelpResource: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Help, IsRequired: true, EntityHeaderPickerUrl: "/api/deviceconfigs",
            WaterMark: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader DefaultDeviceConfiguration { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Product, FieldType: FieldTypes.ProductPicker, WaterMark: DeviceLibraryResources.Names.DeviceType_Product_Select, ResourceType: typeof(DeviceLibraryResources), IsRequired: false, IsUserEditable: true)]
        public EntityHeader Product { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_BillOfMaterial, WaterMark: DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select,
            FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<SectionGrouping<BOMItem>> BillOfMaterial { get; set; }

        [FKeyProperty("MediaResource", WhereClause: "Resources[*].Id = {0}")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Resources, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<MediaResourceSummary> Resources { get; set; }

        [FKeyProperty(nameof(Equipment), typeof(Equipment), "AssociatedEquipment[*].Id = {0}")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_AssociatedTools, FieldType: FieldTypes.ChildListInlinePicker, EntityHeaderPickerUrl: "/api/equipmentitems", ResourceType: typeof(DeviceLibraryResources))]
        public List<EntityHeader> Equipment { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(DeviceLibraryResources))]
        public string Icon { get; set; }


        [FKeyProperty("Firmware", WhereClause:"Firmware.Id = {0}")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Firmware, WaterMark: DeviceLibraryResources.Names.DeviceType_FirmwareSelect, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader Firmware { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Firmware_Revision, WaterMark: DeviceLibraryResources.Names.DeviceType_Firmware_RevisionSelect, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader FirmwareRevision { get; set; }

        [FKeyProperty("Firmware", WhereClause: "Firmware.Id = {0}")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_QAFirmware, WaterMark: DeviceLibraryResources.Names.DeviceType_QAFirmware_Select, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader QaFirmware { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_QAFirmwareRevision, WaterMark: DeviceLibraryResources.Names.DeviceType_QAFirmwareRevision_Select, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader QaFirmwareRevision { get; set; }



        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_ProvisioningQAChecks, FieldType: FieldTypes.HtmlEditor, ResourceType: typeof(DeviceLibraryResources))]
        public string ProvisioningQAChecks { get; set; }

        public DeviceTypeSummary CreateSummary()
        {
            var summary = new DeviceTypeSummary()
            {
                Description = Description,
                Name = Name,
                Id = Id,
                Icon = Icon,
                Key = Key,
                Manufacturer = Manufacturer,
                ModelNumber = ModelNumber,
                Category = Category
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
                nameof(DeviceType.IsPublic),
                nameof(DeviceType.Category),
                nameof(DeviceType.Product),
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
                nameof(DeviceType.QaFirmware),
                nameof(DeviceType.QaFirmwareRevision),
                nameof(DeviceType.Resources),
                nameof(DeviceType.ProvisioningQAChecks),
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
                nameof(DeviceType.IsPublic),
                nameof(DeviceType.Category),
                nameof(DeviceType.Product),
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
      DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.Summary, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-device-model", Cloneable: true,
      SaveUrl: "/api/devicetype", GetUrl: "/api/devicetype/{id}", GetListUrl: "/api/devicetypes", FactoryUrl: "/api/devicetype/factory", DeleteUrl: "/api/devicetype/{id}")]
    public class DeviceTypeSummary : CategorizedSummaryData
    {
        public String DefaultDeviceConfigId { get; set; }
        public String DefaultDeviceConfigName { get; set; }

        public string ModelNumber { get; set; }
        public string Manufacturer { get; set; }
    }
}
