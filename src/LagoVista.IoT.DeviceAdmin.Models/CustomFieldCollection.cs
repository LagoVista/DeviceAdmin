using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using System.Collections.Generic;
using System;
using LagoVista.IoT.DeviceAdmin.Models.Resources;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    /// <summary>
    /// This won't really be used on a device configuration but can be used for an organization
    /// to help build templates for adding a number of custom fields at once.
    /// </summary>
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.CustomFieldCollection_Title, Resources.DeviceLibraryResources.Names.CustomFieldCollection_Help, Resources.DeviceLibraryResources.Names.CustomFieldCollection_Description, 
        EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources), FactoryUrl: "/api/deviceadmin/factory/customfieldcollection")]
    public class CustomFieldCollection : KeyOwnedDeviceAdminBase, IOwnedEntity, IFormDescriptor
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.CustomField_Label, FieldType: FieldTypes.ChildListInline, FactoryUrl: "/api/deviceadmin/factory/customfield", ResourceType: typeof(DeviceLibraryResources))]
        public List<CustomField> CustomFields { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(CustomFieldCollection.Name),
                nameof(CustomFieldCollection.Key),
                nameof(CustomFieldCollection.Description),
                nameof(CustomFieldCollection.CustomFields),
            };
        }
    }
}
