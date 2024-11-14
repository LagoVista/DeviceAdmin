using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.DeviceType_Title, DeviceLibraryResources.Names.DeviceType_Help,
            DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-device-model", Cloneable: true,
            SaveUrl: "/api/component/package", GetUrl: "/api/component/package/{id}", GetListUrl: "/api/component/packages", FactoryUrl: "/api/component/package/factory", DeleteUrl: "/api/component/package/{id}",
            ListUIUrl: "/iotstudio/device/devicemodels", EditUIUrl: "/iotstudio/device/devicemodel/{id}", CreateUIUrl: "/iotstudio/device/devicemodel/add")]
    public class ComponentPackage : IoTModelBase, IValidateable, IFormDescriptor, IFormDescriptorCol2, ISummaryFactory, IIDEntity
    {

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_PackageId, FieldType: FieldTypes.Text, IsRequired:true, ResourceType: typeof(DeviceLibraryResources))]
        public string PackageId { get; set; }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_PartWidth, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal Width { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_PartLength, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal Length { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_PartHeight, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal Height { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_TapeWidth, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal TapeWidth { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_Rotation, FieldType: FieldTypes.Integer, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public int Rotation { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_SpacingX, FieldType: FieldTypes.Integer, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal SpacingX { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_HoleSpacing, FieldType: FieldTypes.Integer, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal HoleSpacing { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_CenterX, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal CenterX { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_HoleSpacing, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal CenterY { get; set; }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_SpecificationPage, FieldType: FieldTypes.WebLink, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal SpecificationPage { get; set; }

        public ComponentPackageSummary CreateSummary()
        {
            return new ComponentPackageSummary()
            {

            };
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(PackageId),
                nameof(Width),
                nameof(Length),
                nameof(Height),                
                nameof(Notes),
            };
        }

        public List<string> GetFormFieldsCol2()
        {
            return new List<string>()
            {
                nameof(SpecificationPage),
                nameof(Rotation),
                nameof(TapeWidth),
                nameof(SpacingX),
                nameof(HoleSpacing),
                nameof(CenterX),
                nameof(CenterY),
            };
        }
    }

    public class ComponentPackageSummary : SummaryData
    {
        public string PackageId { get; set; }
    }
}
