using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.UnitSet_Title, Resources.DeviceLibraryResources.Names.UnitSet_Help, Resources.DeviceLibraryResources.Names.UnitSet_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class UnitSet : KeyOwnedDeviceAdminBase, IValidateable, INoSQLEntity, IOwnedEntity, IFormDescriptor
    {
        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.UnitSet_IsLocked, HelpResource: DeviceLibraryResources.Names.UnitSet_IsLocked_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsLocked { get; set; }

        public EntityHeader LockedBy { get; set; }

        public String LockedDateStamp { get; set; }


        public UnitSet()
        {
            Units = new List<Unit>();
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.UnitSet_Units, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<Unit> Units { get; set; }

        public UnitSetSummary CreateUnitSetSummary()
        {
            return new UnitSetSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                Name = Name
            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(UnitSet.Name),
                nameof(UnitSet.Key),
                nameof(UnitSet.Description),
                nameof(UnitSet.IsLocked),
                nameof(UnitSet.Units),
            };
        }
    }

    public class UnitSetSummary : IIDEntity, IKeyedEntity, INamedEntity
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
