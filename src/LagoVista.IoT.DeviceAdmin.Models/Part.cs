using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.MediaServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Part_Title,
        DeviceLibraryResources.Names.Part_Help, DeviceLibraryResources.Names.Part_Description,
                  EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources),
            GetUrl:"/api/part/{id}", GetListUrl: "/api/parts", SaveUrl: "/api/part", DeleteUrl: "/api/part/{id}", FactoryUrl: "/api/part/factory")]
    public class Part : EntityBase, IValidateable, IFormDescriptor, IDescriptionEntity, ISummaryFactory
    {
        public Part()
        {
            Resources = new List<MediaResourceSummary>();
        }


        [CloneOptions(false)]
        [FormField(LabelResource: LagoVista.IoT.DeviceAdmin.Models.Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Part_PartNumber, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string PartNumber { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Part_SKU, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string Sku { get; set; }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Part_Manufacturer, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacturer { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Common_Resources, FieldType: FieldTypes.MediaResources, ResourceType: typeof(DeviceLibraryResources))]
        public List<MediaResourceSummary> Resources { get; set; }

        public PartSummary CreateSummary()
        {
            return new PartSummary()
            {
                Description = Description,
                Id = Id,
                IsPublic = IsPublic,
                Key = "N/A",
                Name = Name,
                PartNumber = PartNumber,
                Sku = Sku
            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Manufacturer),
                nameof(Description),
                nameof(PartNumber),
                nameof(Sku),
                nameof(Resources)
            };
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }


    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Part_Title,
        DeviceLibraryResources.Names.Part_Help, DeviceLibraryResources.Names.Part_Description,
                  EntityDescriptionAttribute.EntityTypes.Summary, ResourceType: typeof(DeviceLibraryResources),
            GetUrl: "/api/part/{id}", GetListUrl: "/api/parts", SaveUrl: "/api/part", DeleteUrl: "/api/part/{id}", FactoryUrl: "/api/part/factory")]
    public class PartSummary : SummaryData
    {
        public string PartNumber { get; set; }
        public string Sku { get; set; }
    }
}
