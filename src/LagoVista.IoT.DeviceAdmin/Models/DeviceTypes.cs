using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.DeviceType_Title, Resources.DeviceLibraryResources.Names.DeviceType_Help, Resources.DeviceLibraryResources.Names.DeviceType_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class DeviceType : KeyOwnedDeviceAdminBase, IValidateable, INoSQLEntity, IOwnedEntity
    {
        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_Manufacturer, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacturer { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_ModelNumber, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string ModelNumber { get; set; }

        public DeviceTypeSummary CreateSummary()
        {
            return new DeviceTypeSummary()
            {
                 Description = Description,
                 Name = Name,
                 Id = Id,
                 Key = Key
            };
        }
    }

    public class DeviceTypeSummary : SummaryData
    {

    }

}
