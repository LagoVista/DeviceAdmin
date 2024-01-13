using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Equipment_Title,
        DeviceLibraryResources.Names.Equipment_Help, DeviceLibraryResources.Names.Equipment_Description,
                  EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-pz-troubleshooting",
        SaveUrl: "/api/equipment", GetListUrl: "/api/equipmentitems", GetUrl: "/api/equipment/{id}", FactoryUrl: "/api/equipment/factory", DeleteUrl: "/api/equipment/{id}")]
    public class Equipment : IoTModelBase, IValidateable, IFormDescriptor, ISummaryFactory, IIDEntity
    {
        public Equipment()
        {
            Resources = new List<MediaServices.Models.MediaResourceSummary>();
            Icon = "icon-pz-troubleshooting";
        }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Picture, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public List<MediaServices.Models.MediaResourceSummary> Resources { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(DeviceLibraryResources))]
        public string Icon { get; set; }


        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Icon),
                nameof(Description),
            };
        }

        public EquipmentSummary CreateSummary()
        {
            return new EquipmentSummary()
            {
                Id = Id,
                Key = Key,
                Icon = Icon,
                Description = Description,
                IsPublic = IsPublic,
                Name = Name
            };
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Equipment_Title,
        DeviceLibraryResources.Names.Equipment_Help, DeviceLibraryResources.Names.Equipment_Description,
                  EntityDescriptionAttribute.EntityTypes.Summary, ResourceType: typeof(DeviceLibraryResources),
        SaveUrl: "/api/equipment", GetListUrl: "/api/equipmentitems", GetUrl: "/api/equipment/{id}", FactoryUrl: "/api/equipment/factory", DeleteUrl: "/api/equipment/{id}")]
    public class EquipmentSummary : SummaryData
    {

    }
}
