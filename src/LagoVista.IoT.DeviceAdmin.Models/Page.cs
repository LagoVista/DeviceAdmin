﻿using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.Page_Title, Resources.DeviceLibraryResources.Names.Page_Help, Resources.DeviceLibraryResources.Names.Page_Description, 
        EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources), FactoryUrl: "/api/deviceadmin/factory/page")]
    public class Page : IFormDescriptor
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Page_Name, FieldType:FieldTypes.Text, IsRequired:true, ResourceType: typeof(DeviceLibraryResources))]
        public string Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Page_PageNumber, FieldType:FieldTypes.Integer, IsRequired:true, IsUserEditable:false, ResourceType: typeof(DeviceLibraryResources))]
        public int PageNumber { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(PageNumber),
                nameof(Description)
            };
        }
    }
}
