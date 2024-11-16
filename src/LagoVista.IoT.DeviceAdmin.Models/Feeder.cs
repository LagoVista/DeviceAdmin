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
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Feeder_Title, DeviceLibraryResources.Names.Feeder_Description,
            DeviceLibraryResources.Names.Feeder_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-pz-stamp-2", Cloneable: true,
            SaveUrl: "/api/mfg/Feeder/", GetUrl: "/api/mfg/Feeder//{id}", GetListUrl: "/api/mfg/Feeder/s", FactoryUrl: "/api/mfg/Feeder//factory",
            DeleteUrl: "/api/mfg/Feeder//{id}", ListUIUrl: "/mfg/Feeder/s", EditUIUrl: "/mfg/Feeder//{id}", CreateUIUrl: "/mfg/Feeder//add")]
    public class Feeder : IoTModelBase, IValidateable, IFormDescriptor, ISummaryFactory, IIDEntity
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

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Feeders_Title, DeviceLibraryResources.Names.Feeder_Description,
            DeviceLibraryResources.Names.Feeder_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-pz-stamp-2", Cloneable: true,
            SaveUrl: "/api/mfg/feeder", GetUrl: "/api/mfg/feeder/{id}", GetListUrl: "/api/mfg/feeder", FactoryUrl: "/api/feeder/factory",
            DeleteUrl: "/api/mfg/feeder/{id}", ListUIUrl: "/mfg/feeders", EditUIUrl: "/mfg/feeder/{id}", CreateUIUrl: "/mfg/feeder/add")]
    public class FeederSummary : SummaryData
    {

    }
}
