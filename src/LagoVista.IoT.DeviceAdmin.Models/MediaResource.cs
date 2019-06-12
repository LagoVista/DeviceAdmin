using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public enum MediaResourceTypes
    {
        [EnumLabel(MediaResource.DeviceResourceTypes_Manual, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Manual, typeof(Resources.DeviceLibraryResources))]
        Manual,
        [EnumLabel(MediaResource.DeviceResourceTypes_UserGuide, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_UserGuide, typeof(Resources.DeviceLibraryResources))]
        UserGuide,
        [EnumLabel(MediaResource.DeviceResourceTypes_Specification, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Specification, typeof(Resources.DeviceLibraryResources))]
        Specification,
        [EnumLabel(MediaResource.DeviceResourceTypes_PartsList, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_PartsList, typeof(Resources.DeviceLibraryResources))]
        PartList,
        [EnumLabel(MediaResource.DeviceResourceTypes_Picture, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Picture, typeof(Resources.DeviceLibraryResources))]
        Picture,
        [EnumLabel(MediaResource.DeviceResourceTypes_Video, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Video, typeof(Resources.DeviceLibraryResources))]
        Video,
        [EnumLabel(MediaResource.DeviceResourceTypes_Other, Resources.DeviceLibraryResources.Names.DeviceResourceTypes_Other, typeof(Resources.DeviceLibraryResources))]
        Other,
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.DeviceResources_Title, Resources.DeviceLibraryResources.Names.DeviceResources_Help, Resources.DeviceLibraryResources.Names.DeviceResources_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class MediaResource: IValidateable 
    {

        public const string DeviceResourceTypes_Manual = "manual";
        public const string DeviceResourceTypes_UserGuide = "userguide";
        public const string DeviceResourceTypes_Specification = "specification";
        public const string DeviceResourceTypes_PartsList = "partslist";
        public const string DeviceResourceTypes_Picture = "picture";
        public const string DeviceResourceTypes_Video = "video";
        public const string DeviceResourceTypes_Other = "other";

        public MediaResource()
        {
            IsFileUpload = true;
        }

        public string Id { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceResources_FileName, FieldType: FieldTypes.Text, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources))]
        public string FileName { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, IsRequired:true, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public string Key { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceResource_IsFileUpload, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsFileUpload { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceResource_Link, HelpResource: Resources.DeviceLibraryResources.Names.DeviceResource_Link_Help,  FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Link { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceResource_ContentLength, FieldType: FieldTypes.Integer,IsUserEditable:false, ResourceType: typeof(DeviceLibraryResources))]
        public long ContentSize { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceResources_MimeType,  IsUserEditable:false, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string MimeType { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, IsRequired:true, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Name { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceResources_ResourceType, WaterMark: Resources.DeviceLibraryResources.Names.DeviceResource_SelectType, IsRequired:true, EnumType:typeof(MediaResourceTypes), FieldType: FieldTypes.Picker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<MediaResourceTypes> ResourceType { get; set; }

        public void SetContentType(string contentType)
        {
            FileName = $"{Id}.media";
            MimeType = "application/octet-stream";

            if (contentType.ToLower().Contains("gif"))
            {
                FileName = $"{Id}.gif";
                MimeType = "image/gif";
            }
            else if (contentType.ToLower().Contains("png"))
            {
                FileName = $"{Id}.png";
                MimeType = "image/png";
            }
            else if (contentType.ToLower().Contains("jpg"))
            {
                FileName = $"{Id}.jpg";
                MimeType = "image/jpeg";
            }
            else if (contentType.ToLower().Contains("jpeg"))
            {
                FileName = $"{Id}.jpeg";
                MimeType = "image/jpeg";
            }
            else if (contentType.ToLower().Contains("pdf"))
            {
                FileName = $"{Id}.pdf";
                MimeType = "application/pdf";
            }
            else if (contentType.ToLower().Contains("csv"))
            {
                FileName = $"{Id}.csv";
                MimeType = "text/plain";
            }
        }

        [CustomValidator]
        public void Validate(ValidationResult result)
        {
            if(IsFileUpload)
            {
                Link = String.Empty;

                if(String.IsNullOrEmpty(FileName))
                {
                    result.AddUserError("Must provide file.");
                }
            }
            else
            {
                ContentSize = 0;
                MimeType = null;
                FileName = null;

                if(String.IsNullOrEmpty(Link))
                {
                    result.AddUserError("Must provide link.");
                }
            }


        }
    }
}
