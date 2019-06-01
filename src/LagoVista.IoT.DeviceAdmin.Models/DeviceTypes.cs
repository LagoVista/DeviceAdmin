using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.DeviceType_Title, Resources.DeviceLibraryResources.Names.DeviceType_Help, Resources.DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class DeviceType : KeyOwnedDeviceAdminBase, IValidateable, INoSQLEntity, IOwnedEntity, IFormDescriptor
    {
        public DeviceType()
        {
            BillOfMaterial = new List<DeviceBOMItem>();
            DeviceResources = new List<DeviceResource>();
        }

        public const string DeviceResourceTypes_Manual = "manual";
        public const string DeviceResourceTypes_UserGuide = "userguide";
        public const string DeviceResourceTypes_Specification = "specification";
        public const string DeviceResourceTypes_PartsList = "partslist";
        public const string DeviceResourceTypes_Picture = "picture";
        public const string DeviceResourceTypes_Video = "video";
        public const string DeviceResourceTypes_Other = "other";

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_Manufacturer, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacturer { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_ModelNumber, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string ModelNumber { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_DefaultConfiguration, HelpResource: Resources.DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Help,  WaterMark: Resources.DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select, FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader DefaultDeviceConfiguration { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_BillOfMaterial, WaterMark: Resources.DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<DeviceBOMItem> BillOfMaterial { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_Resources, WaterMark: Resources.DeviceLibraryResources.Names.DeviceType_DefaultConfiguration_Select, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<DeviceResource> DeviceResources { get; set; }

        public DeviceTypeSummary CreateSummary()
        {
            var summary = new DeviceTypeSummary()
            {
                 Description = Description,
                 Name = Name,
                 Id = Id,
                 Key = Key,
            };

            if(DefaultDeviceConfiguration != null && !DefaultDeviceConfiguration.IsEmpty())
            {
                summary.DefaultDeviceConfigId = DefaultDeviceConfiguration.Id;
                summary.DefaultDeviceConfigName = DefaultDeviceConfiguration.Text;
            }

            return summary;
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(DeviceType.Name),
                nameof(DeviceType.Key),
                nameof(DeviceType.ModelNumber),
                nameof(DeviceType.DefaultDeviceConfiguration),
                nameof(DeviceType.Manufacturer),
                nameof(DeviceType.Description),
            };
        }
    }

    public class DeviceTypeSummary : SummaryData
    {
        public String DefaultDeviceConfigId { get; set; }
        public String DefaultDeviceConfigName { get; set; }
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.DeviceBOMItem_Title, Resources.DeviceLibraryResources.Names.DeviceBOMItem_Help, Resources.DeviceLibraryResources.Names.DeviceBOMItem_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class DeviceBOMItem
    {
        public DeviceBOMItem()
        {
            BOMItemResources = new List<DeviceResource>();
        }

        public string Id { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceBOMItem_PartNumber, FieldType: FieldTypes.Text, IsRequired:true, ResourceType: typeof(DeviceLibraryResources))]
        public string PartNumber { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, FieldType: FieldTypes.Text, IsRequired: true, ResourceType: typeof(DeviceLibraryResources))]
        public string Name { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceBOMItem_Manufacturer, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacturer { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Desription { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceBOMItem_AssemblyNumber, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string AssemblyNumber { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceBOMItem_Quantity, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int Quantity { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceBOMItem_Quantity, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Link { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceBOMItem_Picture, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public List<DeviceResource> BOMItemResources { get; set; }
    }

    public enum DeviceResourceTypes
    {
        [EnumLabel(DeviceType.DeviceResourceTypes_Manual, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Manual, typeof(Resources.DeviceLibraryResources))]
        Manual,
        [EnumLabel(DeviceType.DeviceResourceTypes_UserGuide, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_UserGuide, typeof(Resources.DeviceLibraryResources))]
        UserGuide,
        [EnumLabel(DeviceType.DeviceResourceTypes_Specification, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Specification, typeof(Resources.DeviceLibraryResources))]
        Specification,
        [EnumLabel(DeviceType.DeviceResourceTypes_PartsList, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_PartsList, typeof(Resources.DeviceLibraryResources))]
        PartList,
        [EnumLabel(DeviceType.DeviceResourceTypes_Picture, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Picture, typeof(Resources.DeviceLibraryResources))]
        Picture,
        [EnumLabel(DeviceType.DeviceResourceTypes_Video, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Video, typeof(Resources.DeviceLibraryResources))]
        Video,
        [EnumLabel(DeviceType.DeviceResourceTypes_Other, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Other, typeof(Resources.DeviceLibraryResources))]
        Other,
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.DeviceResources_Title, Resources.DeviceLibraryResources.Names.DeviceResources_Help, Resources.DeviceLibraryResources.Names.DeviceResources_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class DeviceResource 
    {
        public string Id { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceResources_FileName, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string FileName { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public string Key { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceResources_MimeType, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string MimeType { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, IsRequired:true, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Name { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceResources_ResourceType, FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<DeviceResourceTypes> ResourceType { get; set; }
    }
}
