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
    public class Part : ModelBase, IIDEntity, INamedEntity, IOwnedEntity, IValidateable, IAuditableEntity, INoSQLEntity
    {
        public Part()
        {
            Resources = new List<MediaResourceSummary>();
        }

        public string DatabaseName { get; set; }
        public string EntityType { get; set; }

        [CloneOptions(false)]
        [JsonProperty("id")]
        [FormField(LabelResource: LagoVista.IoT.DeviceAdmin.Models.Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        [CloneOptions(false)]
        [FormField(LabelResource: LagoVista.IoT.DeviceAdmin.Models.Resources.DeviceLibraryResources.Names.Common_CreationDate, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String CreationDate { get; set; }

        [CloneOptions(false)]
        public EntityHeader CreatedBy { get; set; }

        [CloneOptions(false)]
        [FormField(LabelResource: LagoVista.IoT.DeviceAdmin.Models.Resources.DeviceLibraryResources.Names.Common_LastUpdated, FieldType: FieldTypes.JsonDateTime, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String LastUpdatedDate { get; set; }

        [CloneOptions(false)]
        public EntityHeader LastUpdatedBy { get; set; }

        private String _name;
        [CloneOptions(false)]
        [FormField(LabelResource: LagoVista.IoT.DeviceAdmin.Models.Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public String Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private String _description;
        [CloneOptions(false)]
        [FormField(LabelResource: LagoVista.IoT.DeviceAdmin.Models.Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description
        {
            get { return _description; }
            set { Set(ref _description, value); }
        }

        [FormField(LabelResource: LagoVista.IoT.DeviceAdmin.Models.Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Part_PartNumber, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string PartNumber { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Part_SKU, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string Sku { get; set; }


        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Part_Manufacturer, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacturer { get; set; }

        [FormField(LabelResource: Models.Resources.DeviceLibraryResources.Names.Common_Resources, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<MediaResourceSummary> Resources { get; set; }

        public PartSummary CreatePartSummary()
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
    }


    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.Part_Title,
        DeviceLibraryResources.Names.Part_Help, DeviceLibraryResources.Names.Part_Description,
                  EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources),
            GetUrl: "/api/part/{id}", GetListUrl: "/api/parts", SaveUrl: "/api/part", DeleteUrl: "/api/part/{id}", FactoryUrl: "/api/part/factory")]
    public class PartSummary : SummaryData
    {
        public string PartNumber { get; set; }
        public string Sku { get; set; }
    }
}
