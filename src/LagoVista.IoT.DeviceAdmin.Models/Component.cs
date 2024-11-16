using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Component_Title, DeviceLibraryResources.Names.DeviceType_Help,
        DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-core-1", Cloneable: true,
        SaveUrl: "/api/mfg/compoent", GetUrl: "/api/mfg/compoent/{id}", GetListUrl: "/api/mfg/compoents", FactoryUrl: "/api/mfg/compoent/factory", DeleteUrl: "/api/mfg/compoent/{id}",
        ListUIUrl: "/mfg/components", EditUIUrl: "/mfg/component/{id}", CreateUIUrl: "/mfg/component/add")]
    public class Component : IoTModelBase, IValidateable, IFormDescriptor, IFormDescriptorCol2, ISummaryFactory, IIDEntity
    {

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_ComponentType, FieldType: FieldTypes.Category, CustomCategoryType:"component_type", WaterMark:DeviceLibraryResources.Names.Component_ComponentType_Select, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader ComponentType { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Room, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Room { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_ShelfUnit, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string ShelfUnit { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_ShelfUnit, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Shelf { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Bin, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Bin { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(DeviceLibraryResources))]
        public string Icon { get; set; } = "icon-ae-core-1";


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_PackageType, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader ComponentPackage { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_VendorLink, FieldType: FieldTypes.WebLink, ResourceType: typeof(DeviceLibraryResources))]
        public string VendorLink { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_MfgPartNumb, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string ManufacturePartNumber { get; set; }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_DataSheet, FieldType: FieldTypes.WebLink, ResourceType: typeof(DeviceLibraryResources))]
        public string DataSheet { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Value, FieldType: FieldTypes.WebLink, ResourceType: typeof(DeviceLibraryResources))]
        public string Value { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Attr1, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Attr1 { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Attr2, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Attr2 { get; set; }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_QuantityOnHand, FieldType: FieldTypes.Decimal, ResourceType: typeof(DeviceLibraryResources))]
        public decimal QuantityOnHand { get; set; }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_QuantityOnOrder, FieldType: FieldTypes.Decimal, ResourceType: typeof(DeviceLibraryResources))]
        public decimal QuantityOnOrder { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Cost, FieldType: FieldTypes.Money, ResourceType: typeof(DeviceLibraryResources))]
        public decimal Cost { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_ExtendedPrice, FieldType: FieldTypes.Money, ResourceType: typeof(DeviceLibraryResources))]
        public decimal ExtendedPrice { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_PartNumber, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string PartNumber { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_PartPack, FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl:"/api/mfg/partpacks", ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader PartPack { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Feeder, WaterMark: DeviceLibraryResources.Names.Component_Feeder_Select, 
            FieldType: FieldTypes.EntityHeaderPicker, EntityHeaderPickerUrl: "/api/mfg/feeders", ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader Feeder { get; set; }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Row, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int? Row { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.ComponentPurchase_Title, FactoryUrl: "/api/mfg/component/purchase/factory", FieldType: FieldTypes.ChildListInline, ResourceType: typeof(DeviceLibraryResources))]
        public List<ComponentPurchase> Purchases { get; set; } = new List<ComponentPurchase>();


        public ComponentSummary CreateSummary()
        {
            return new ComponentSummary()
            {
                Id = Id,
                Name = Name,
                Key = Key,
                PartNumber = PartNumber,
                QuantityOnHand = QuantityOnHand,
                QuantityOnOrder = QuantityOnOrder,
                IsPublic = IsPublic,
                Icon = Icon,
                Description = Description
            };
        }


        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Icon),
                nameof(PartNumber),
                nameof(ComponentType),
                nameof(ComponentPackage),
                nameof(Value),
                nameof(Attr1),
                nameof(Attr2),
            };
        }

        public List<string> GetFormFieldsCol2()
        {
            return new List<string>()
            {
                nameof(ManufacturePartNumber),
                nameof(VendorLink),
                nameof(DataSheet),
                nameof(ExtendedPrice),
                nameof(Cost),
                nameof(ShelfUnit),
                nameof(Shelf),
                nameof(Bin),
                nameof(PartPack),
                nameof(Row),
                nameof(Feeder),
                nameof(Purchases),
            };
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Component_Title, DeviceLibraryResources.Names.DeviceType_Help,
        DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-core-1", Cloneable: true,
        SaveUrl: "/api/compoent", GetUrl: "/api/compoent/{id}", GetListUrl: "/api/compoents", FactoryUrl: "/api/compoent/factory", DeleteUrl: "/api/compoent/{id}",
        ListUIUrl: "/mfg/components", EditUIUrl: "/mfg/component/{id}", CreateUIUrl: "/mfg/component/add")]
    public class ComponentSummary : SummaryData
    {
        public string PartNumber { get; set; }
        public decimal QuantityOnOrder { get; set; }
        public decimal QuantityOnHand{ get; set; }
    }
}
