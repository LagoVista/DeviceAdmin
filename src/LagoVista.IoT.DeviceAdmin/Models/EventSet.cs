using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.EventSet_Title, Resources.DeviceLibraryResources.Names.EventSet_Help, Resources.DeviceLibraryResources.Names.EventSet_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class EventSet : KeyOwnedDeviceAdminBase, IValidateable, INoSQLEntity
    {
        public EventSet()
        {
            Events = new List<Event>();
        }            

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.EventSet_IsLocked, HelpResource: DeviceLibraryResources.Names.EventSet_IsLocked_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsLocked { get; set; }

        public EntityHeader LockedBy { get; set; }

        public String LockedDateStamp { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.EventSet_Events, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<Event> Events { get; set; }

        public EventSetSummary CreateEventSetSummary()
        {
            return new EventSetSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                Name = Name
            };
        }
    }

    public class EventSetSummary : IIDEntity, IKeyedEntity, INamedEntity
    {
        public string Id { get; set; }
        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources))]
        public String Name { get; set; }
        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResources: Resources.DeviceLibraryResources.Names.Common_Key_Help, ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }
        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }
    }
}
