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
                  EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources),
        SaveUrl: "/api/equipment", GetListUrl: "/api/equipmentitems", GetUrl: "/api/equipment/{id}", FactoryUrl: "/api/equipment/factory", DeleteUrl: "/api/equipment/{id}")]
    public class Equipment : IoTModelBase, IValidateable, IFormDescriptor
    {
        public Equipment()
        {
            Resources = new List<MediaServices.Models.MediaResourceSummary>();
        }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.DeviceBOMItem_Picture, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public List<MediaServices.Models.MediaResourceSummary> Resources { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Description),
            };
        }

        public EquipmentSummary CreateSummary()
        {
            return new EquipmentSummary()
            {
                Id = Id,
                Key = Key,
                Description = Description,
                IsPublic = IsPublic,
                Name = Name
            };
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
