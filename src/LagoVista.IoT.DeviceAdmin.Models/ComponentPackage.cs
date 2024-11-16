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
    public enum PackageTypes
    {
        [EnumLabel(ComponentPackage.PartType_ThroughHole, DeviceLibraryResources.Names.PartType_ThroughHole, typeof(DeviceLibraryResources))]
        ThroughHole,
        [EnumLabel(ComponentPackage.PartType_SurfaceMount, DeviceLibraryResources.Names.PartType_SurfaceMount, typeof(DeviceLibraryResources))]
        SurfaceMount,
        [EnumLabel(ComponentPackage.PartType_Hardware, DeviceLibraryResources.Names.PartType_Hardware, typeof(DeviceLibraryResources))]
        Hardware
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.ComponentPackage_TItle, DeviceLibraryResources.Names.ComponentPackage_Description,
            DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-pz-stamp-2", Cloneable: true,
            SaveUrl: "/api/mfg/component/package", GetUrl: "/api/mfg/component/package/{id}", GetListUrl: "/api/mfg/component/packages", FactoryUrl: "/api/mfg/component/package/factory", DeleteUrl: "/api/mfg/component/package/{id}",
            ListUIUrl: "/mfg/component/packages", EditUIUrl: "/mfg/component/package/{id}", CreateUIUrl: "/mfg/component/package/add")]
    public class ComponentPackage : IoTModelBase, IValidateable, IFormDescriptor, IFormDescriptorCol2, ISummaryFactory, IIDEntity
    {
        public const string PartType_ThroughHole = "throughhole";
        public const string PartType_SurfaceMount = "surfacemount";
        public const string PartType_Hardware = "hardware";




        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_PackageId, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string PackageId { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(DeviceLibraryResources))]
        public string Icon { get; set; } = "icon-pz-stamp-2";


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

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_SpacingX, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal SpacingX { get; set; } = 4;

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_HoleSpacing, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal HoleSpacing { get; set; } = 4;

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_CenterX, HelpResource: DeviceLibraryResources.Names.ComponentPackage_CenterX_Help, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal CenterX { get; set; } = 2;

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_CenterY, HelpResource: DeviceLibraryResources.Names.ComponentPackage_CenterY_Help, FieldType: FieldTypes.Decimal, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public decimal CenterY { get; set; } = 6;


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPackage_SpecificationPage, FieldType: FieldTypes.WebLink, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string SpecificationPage { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.ComponentPackage_PartType, EnumType:typeof(PackageTypes), WaterMark: DeviceLibraryResources.Names.ComponentPackage_PartType_Select, FieldType: FieldTypes.Picker, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<PackageTypes> PackageType { get; set; }

        public ComponentPackageSummary CreateSummary()
        {
            return new ComponentPackageSummary()
            {
                Description = Description,
                Icon = Icon,
                Name = Name,
                Key = Key,
                Id = Id,
                IsPublic = IsPublic,
                PackageId = PackageId,
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
                nameof(Icon),
                nameof(PackageId),
                nameof(PackageType),
                nameof(Width),
                nameof(Length),
                nameof(Height),
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

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.ComponentPackage_TItle, DeviceLibraryResources.Names.ComponentPackage_Description,
            DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-pz-stamp-2", Cloneable: true,
            SaveUrl: "/api/component/package", GetUrl: "/api/component/package/{id}", GetListUrl: "/api/component/packages", FactoryUrl: "/api/component/package/factory", DeleteUrl: "/api/component/package/{id}",
            ListUIUrl: "/mfg/component/packages", EditUIUrl: "/mfg/component/package/{id}", CreateUIUrl: "/mfg/component/package/add")]
    public class ComponentPackageSummary : SummaryData
    {
        public string PackageId { get; set; }
    }
}
