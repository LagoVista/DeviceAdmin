using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.StateSet_Title, Resources.DeviceLibraryResources.Names.StateSet_Help, Resources.DeviceLibraryResources.Names.StateSet_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class StateSet : KeyOwnedDeviceAdminBase, IValidateable, INoSQLEntity
    {
        public StateSet()
        {
            States = new List<State>();
        }

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateSet_IsLocked, HelpResource: DeviceLibraryResources.Names.StateSet_IsLocked_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsLocked { get; set; }

        public EntityHeader LockedBy { get; set; }

        public String LockedDateStamp { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateSet_States, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<State> States { get; set; }

        public StateSetSummary CreateStateSetSummary()
        {
            return new StateSetSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                Name = Name
            };
        }
    }

    public class StateSetSummary : IIDEntity, IKeyedEntity, INamedEntity
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
