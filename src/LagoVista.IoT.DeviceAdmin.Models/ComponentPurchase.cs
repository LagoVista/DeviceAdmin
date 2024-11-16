using LagoVista.Core;
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.ComponentPurchase_Title, DeviceLibraryResources.Names.ComponentPurchase_Description,
        DeviceLibraryResources.Names.ComponentPurchase_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-device-model", Cloneable: true,
        FactoryUrl: "/api/mfg/component/purchase/factory")]
    public class ComponentPurchase : IIDEntity, INamedEntity, IFormDescriptor
    {
        public ComponentPurchase()
        {
            Id = Guid.NewGuid().ToId();
        }

        public string Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.ComponentPurchase_OrderNumber, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string OrderNumber { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.ComponentPurchase_Vendor, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string Vendor { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.ComponentPurchase_Quantity, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public int Qty { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.ComponentPurchase_OrderDate, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string OrderDate { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(OrderNumber),
                nameof(Vendor),
                nameof(Qty),
                nameof(OrderDate)
            };
        }
    }
}
