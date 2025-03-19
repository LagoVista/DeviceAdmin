using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System;
using LagoVista.Core;
using System.Collections.Generic;
using System.Linq;
using LagoVista.IoT.DeviceAdmin.Models.Resources;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.UnitSet_Title, Resources.DeviceLibraryResources.Names.UnitSet_Help, Resources.DeviceLibraryResources.Names.UnitSet_Description,
        EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-checklist-2",
        SaveUrl: "/api/deviceadmin/unitset", GetUrl: "/api/deviceadmin/unitset/{id}", GetListUrl: "/api/deviceadmin/unitsets", FactoryUrl: "/api/deviceadmin/factory/unitset", DeleteUrl: "/api/deviceadmin/unitset/{id}",
        ListUIUrl: "/iotstudio/settings/unitsets", CreateUIUrl: "/iotstudio/settings/unitset/add", EditUIUrl: "/iotstudio/settings/unitset/{id}")]
    public class UnitSet : IoTModelBase, IValidateable, IFormDescriptor, ILockable, ISummaryFactory, IIconEntity, ICategorized
    {
        public UnitSet()
        {
            Units = new List<Unit>();
            Id = Guid.NewGuid().ToId();
            Icon="icon-ae-checklist-2";
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.UnitSet_IsLocked, HelpResource: DeviceLibraryResources.Names.UnitSet_IsLocked_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsLocked { get; set; }

        public EntityHeader LockedBy { get; set; }

        public String LockedDateStamp { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(DeviceLibraryResources))]
        public string Icon { get; set; }

        public Unit GetDefault()
        {
           return Units.FirstOrDefault(def => def.IsDefault);
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.UnitSet_Units, FactoryUrl: "/api/deviceadmin/factory/unit", FieldType: FieldTypes.ChildListInline, ResourceType: typeof(DeviceLibraryResources))]
        public List<Unit> Units { get; set; }

        public UnitSetSummary CreateSummary()
        {
            return new UnitSetSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                Name = Name,
                Icon = Icon,
                IsLocked = IsLocked,
                Category = Category?.Text,
                CategoryId = Category?.Id,
                CategoryKey = Category?.Key,
                Description = Description
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
                nameof(UnitSet.Icon),
                nameof(UnitSet.Category),
                nameof(UnitSet.Description),
                nameof(UnitSet.IsLocked),
                nameof(UnitSet.Units),
            };
        }

        public UnitSet Clone(bool newId = false, EntityHeader org = null, EntityHeader user = null)
        {
            var unitSet = new UnitSet()
            {
                CreatedBy = user ?? CreatedBy.Clone(),
                OwnerOrganization = org ?? OwnerOrganization.Clone(),
                LastUpdatedBy = user ?? LastUpdatedBy.Clone(),

                CreationDate = CreationDate,
                DatabaseName = DatabaseName,
                Description = Description,
                EntityType = EntityType,
                Id = newId ? Guid.NewGuid().ToId() : Id,
                IsLocked = IsLocked,
                IsPublic = IsPublic,
                IsValid = IsValid,
                Key = Key,
                LastUpdatedDate = LastUpdatedDate,
                LockedDateStamp = LockedDateStamp,
                Name = Name,
                Notes = CloneNotes(),
            };

            if(OwnerUser != null)
            {
                unitSet.OwnerUser = user ?? OwnerUser.Clone();
            }

            if(IsLocked)
            {
                unitSet.LockedBy = user ?? LockedBy.Clone();
            }

            foreach (var unit in Units)
            {
                unitSet.Units.Add(unit.Clone());
            }

            return unitSet;
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.UnitSet_Title, Resources.DeviceLibraryResources.Names.UnitSet_Help, Resources.DeviceLibraryResources.Names.UnitSet_Description,
    EntityDescriptionAttribute.EntityTypes.Summary, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-checklist-2",
    SaveUrl: "/api/deviceadmin/unitset", GetUrl: "/api/deviceadmin/unitset/{id}", GetListUrl: "/api/deviceadmin/unitsets", FactoryUrl: "/api/deviceadmin/factory/unitset", DeleteUrl: "/api/deviceadmin/unitset/{id}")]
    public class UnitSetSummary : SummaryData
    {
        public bool IsLocked { get; set; }
    }
}
