﻿using LagoVista.Core.Attributes;
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


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_Manufacturer, HelpResource: DeviceLibraryResources.Names.DeviceType_Title, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string Manufacture { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_ModelNumber, HelpResource: DeviceLibraryResources.Names.StateSet_IsLocked_Help, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public string ModelNumber { get; set; }

        public DeviceTypeSummary CreateSummary()
        {
            return new DeviceTypeSummary()
            {
                 Description = Description,
                 Name = Name,
                 Id = Name,
                 Key = Key
            };
        }
    }

    public class DeviceTypeSummary : SummaryData
    {

    }

}
