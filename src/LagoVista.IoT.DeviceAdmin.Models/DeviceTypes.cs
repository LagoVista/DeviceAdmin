﻿using LagoVista.Core;
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
    public class DeviceType : IoTModelBase, IValidateable, IFormDescriptor, IFormDescriptorAdvanced, IFormDescriptorBottom, IFormDescriptorAdvancedCol2, IIconEntity, ISummaryFactory, IIDEntity, ICategorized, IFormAdditionalActions
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

        [FKeyProperty("DeviceConfiguration", WhereClause: "DeviceConfiguration.Id = {0}")]
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


        [FKeyProperty("Firmware", WhereClause: "Firmware.Id = {0}")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Firmware, WaterMark: DeviceLibraryResources.Names.DeviceType_FirmwareSelect, HelpResource: DeviceLibraryResources.Names.DeviceType_Firmware_Help, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader Firmware { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_Firmware_Revision, WaterMark: DeviceLibraryResources.Names.DeviceType_Firmware_RevisionSelect, HelpResource: DeviceLibraryResources.Names.DeviceType_Firmware_Revision_Help, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader FirmwareRevision { get; set; }

        [FKeyProperty("Firmware", WhereClause: "Firmware.Id = {0}")]
        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_QAFirmware, WaterMark: DeviceLibraryResources.Names.DeviceType_QAFirmware_Select, HelpResource:DeviceLibraryResources.Names.DeviceType_QAFirmware_Help, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader QaFirmware { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_QAFirmwareRevision, WaterMark: DeviceLibraryResources.Names.DeviceType_QAFirmwareRevision_Select,  FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader QaFirmwareRevision { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_ProvisionQAInstructions,  WaterMark:DeviceLibraryResources.Names.DeviceType_ProvisionQAInstructions_Select, EntityHeaderPickerUrl: "/api/mfg/assembly/instructions", FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader ProvisioningQAInstructions { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_FactoryQAInstructions, WaterMark: DeviceLibraryResources.Names.DeviceType_FactoryQAInstructions_Select, EntityHeaderPickerUrl: "/api/mfg/assembly/instructions", FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader FactoryQAInstructions { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_FactoryQAChecks, FieldType: FieldTypes.HtmlEditor, ResourceType: typeof(DeviceLibraryResources))]
        public string FactoryQAChecks { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_ProvisioningQAChecks, FieldType: FieldTypes.HtmlEditor, ResourceType: typeof(DeviceLibraryResources))]
        public string ProvisioningQAChecks { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_TestingDeviceRepo, DeviceLibraryResources.Names.DeviceType_TestingDeviceRepo_Help, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/devicerepos", ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader TestingDeviceRepo { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_TestingDevice, HelpResource: DeviceLibraryResources.Names.DeviceType_TestingDevice_Help, WaterMark: DeviceLibraryResources.Names.DeviceType_SelectTestingDevice, FieldType: FieldTypes.DevicePicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader TestingDevice { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_WebAppJs, UploadUrl: "/api/deviceype/{id}/main/upload", FieldType: FieldTypes.FileUpload, IsFileUploadImage: false, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<string> WebAppJs { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_PolyfillJs, UploadUrl: "/api/deviceype/{id}/polyfill/upload", FieldType: FieldTypes.FileUpload, IsFileUploadImage: false, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<string> PolyfillJs { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.DeviceType_WebApp_Styles, UploadUrl: "/api/deviceype/{id}/style/upload", FieldType: FieldTypes.FileUpload, IsFileUploadImage: false, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<string> WebAppStyles { get; set; }

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
                CategoryId = Category?.Id,
                Category = Category?.Text,
                CategoryKey = Category?.Key,
            };

            if (DefaultDeviceConfiguration != null && !DefaultDeviceConfiguration.IsEmpty())
            {
                summary.DefaultDeviceConfigId = DefaultDeviceConfiguration.Id;
                summary.DefaultDeviceConfigName = DefaultDeviceConfiguration.Text;
            }

            return summary;
        }

        public List<FormAdditionalAction> GetAdditionalActions()
        {
            return new List<FormAdditionalAction>()
            {
                 new FormAdditionalAction()
                 {
                      ForCreate = false,
                      ForEdit = true,
                       Key = "factoryqa",
                        Title = "Factory QA",
                        Icon = "microsscope"
                 }
            };
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
                nameof(DeviceType.WebAppJs),
                nameof(DeviceType.WebAppStyles),
                nameof(DeviceType.PolyfillJs),
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
                nameof(DeviceType.TestingDeviceRepo),
                nameof(DeviceType.TestingDevice),
                nameof(DeviceType.FactoryQAInstructions),
                nameof(DeviceType.FactoryQAChecks),
                nameof(DeviceType.ProvisioningQAInstructions),
                nameof(DeviceType.ProvisioningQAChecks),
                nameof(DeviceType.BillOfMaterial),
                nameof(DeviceType.Equipment),
                nameof(DeviceType.Resources),
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
    public class DeviceTypeSummary : SummaryData
    {
        public String DefaultDeviceConfigId { get; set; }
        public String DefaultDeviceConfigName { get; set; }

        public string ModelNumber { get; set; }
        public string Manufacturer { get; set; }
    }
}
