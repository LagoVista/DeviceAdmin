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
    DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-device-model", Cloneable: true,
        SaveUrl: "/api/compoent", GetUrl: "/api/compoent/{id}", GetListUrl: "/api/compoents", FactoryUrl: "/api/compoent/factory", DeleteUrl: "/api/compoent/{id}",
        ListUIUrl: "/iotstudio/device/devicemodels", EditUIUrl: "/iotstudio/device/devicemodel/{id}", CreateUIUrl: "/iotstudio/device/devicemodel/add")]
    public class Component : IoTModelBase, IValidateable, IFormDescriptor, IFormDescriptorCol2, ISummaryFactory, IIDEntity
    {
        public string Icon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ComponentSummary CreateSummary()
        {
            return new ComponentSummary()
            {

            };
        }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_ComponentType, FieldType: FieldTypes.Picker, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader ComponentType { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Room, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Room { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_ShelfUnit, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string ShelfUnit { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_ShelfUnit, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Shelf { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Bin, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Bin { get; set; }


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


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Quantity, FieldType: FieldTypes.Decimal, ResourceType: typeof(DeviceLibraryResources))]
        public decimal Quantity { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_Cost, FieldType: FieldTypes.Money, ResourceType: typeof(DeviceLibraryResources))]
        public decimal Cost { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_ExtendedPrice, FieldType: FieldTypes.Money, ResourceType: typeof(DeviceLibraryResources))]
        public decimal ExtendedPrice { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Component_PartNumber, FieldType: FieldTypes.Money, ResourceType: typeof(DeviceLibraryResources))]
        public string PartNumber { get; set; }


        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
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
            };
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    public class ComponentSummary : SummaryData
    {

    }
}
