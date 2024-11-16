using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using static LagoVista.Core.Networking.Models.uPnPDevice;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.PartPack_Title, DeviceLibraryResources.Names.PartPack_Description,
            DeviceLibraryResources.Names.PartPack_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-pz-stamp-2", Cloneable: true,
            SaveUrl: "/api/mfg/partpack", GetUrl: "/api/mfg/partpack/{id}", GetListUrl: "/api/mfg/partpacks", FactoryUrl: "/api/mfg/partpack/factory", DeleteUrl: "/api/mfg/partpack/{id}",
            ListUIUrl: "/mfg/partpacks", EditUIUrl: "/mfg/partpack/{id}", CreateUIUrl: "/mfg/partpack/add")]
    public class PartPack : IoTModelBase, IValidateable, IFormDescriptor, ISummaryFactory, IIDEntity
    {

        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(DeviceLibraryResources))]
    public string Icon { get; set; } = "icon-ae-core-1";


    public FeederSummary CreateSummary()
    {
        return new FeederSummary()
        {
            Id = Id,
            Name = Name,
            Icon = Icon,
            Description = Description,
            Key = Key,
            IsPublic = IsPublic
        };
    }

    public List<string> GetFormFields()
    {
        return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Description)
            };
    }

    Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
    {
        return CreateSummary();
    }

}


    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.PartPacks_Title, DeviceLibraryResources.Names.PartPack_Description,
           DeviceLibraryResources.Names.PartPack_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-pz-stamp-2", Cloneable: true,
           SaveUrl: "/api/mfg/partpack", GetUrl: "/api/mfg/partpack/{id}", GetListUrl: "/api/mfg/partpacks", FactoryUrl: "/api/mfg/partpack/factory", DeleteUrl: "/api/mfg/partpack/{id}",
           ListUIUrl: "/mfg/partpacks", EditUIUrl: "/mfg/partpack/{id}", CreateUIUrl: "/mfg/partpack/add")]
    public class PartPackSummary : SummaryData
    {

    }
}
