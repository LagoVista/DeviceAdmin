using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using System.Collections.Generic;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    /// <summary>
    /// This won't really be used on a device configuration but can be used for an organization
    /// to help build templates for adding a number of custom fields at once.
    /// </summary>
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.CustomFieldCollection_Title,Resources.DeviceLibraryResources.Names.CustomFieldCollection_Help,  Resources.DeviceLibraryResources.Names.CustomFieldCollection_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class CustomFieldCollection : DeviceModelBase, IOwnedEntity
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_Label, FieldType: FieldTypes.OptionsList, ResourceType: typeof(DeviceLibraryResources))]
        public List<CustomField> CustomFields { get; set; }
    }
}
