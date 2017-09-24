using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using LagoVista.Core;
using System.Collections.Generic;
using System.Linq;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.UnitSet_Title, Resources.DeviceLibraryResources.Names.UnitSet_Help, Resources.DeviceLibraryResources.Names.UnitSet_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class UnitSet : KeyOwnedDeviceAdminBase, IValidateable, INoSQLEntity, IOwnedEntity, IFormDescriptor, ILockable
    {
        public UnitSet()
        {
            Units = new List<Unit>();
            Id = Guid.NewGuid().ToId();
        }

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.UnitSet_IsLocked, HelpResource: DeviceLibraryResources.Names.UnitSet_IsLocked_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsLocked { get; set; }

        public EntityHeader LockedBy { get; set; }

        public String LockedDateStamp { get; set; }


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

        [CustomValidator]
        public void Validate(ValidationResult result)
        {
            if (Units == null || Units.Count() == 0)
            {
                result.AddUserError("Unit Sets require at least 1 Unit.");
            }
            else
            {
                if (Units.Select(unit => unit.Key).Distinct().Count() != Units.Count()) result.AddUserError("Duplicate Keys found on Unit Set.");
                if (Units.Where(unit => unit.IsDefault).Count() == 0) result.AddUserError("Could not find Default Unit on Unit Set.  Please add one.");
                if (Units.Where(unit => unit.IsDefault).Count() > 1) result.AddUserError("Found multiple Default Units on Unit Set.  Please ensure you have only one.");
            }
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
