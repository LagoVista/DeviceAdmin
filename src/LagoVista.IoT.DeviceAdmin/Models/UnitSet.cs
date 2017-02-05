using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.UnitSet_Title, Resources.DeviceLibraryResources.Names.UnitSet_Help, Resources.DeviceLibraryResources.Names.UnitSet_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class UnitSet : KeyOwnedDeviceAdminBase, IValidateable, INoSQLEntity
    {
        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        public UnitSet()
        {
            Units = new ObservableCollection<Unit>();
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.UnitSet_Units, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<Unit> Units { get; set; }

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
