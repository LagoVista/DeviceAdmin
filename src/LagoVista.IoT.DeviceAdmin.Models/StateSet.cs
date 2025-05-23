﻿using LagoVista.Core.Attributes;
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
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.StateSet_Title, Resources.DeviceLibraryResources.Names.StateSet_Help, 
        Resources.DeviceLibraryResources.Names.StateSet_Description, EntityDescriptionAttribute.EntityTypes.CoreIoTModel, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-checklist-1",
        DeleteUrl: "/api/statemachine/stateset/{id}", SaveUrl: "/api/statemachine/stateset", GetListUrl: "/api/statemachine/statesets", GetUrl: "/api/statemachine/stateset/{id}", FactoryUrl: "/api/statemachine/factory/stateset",
        ListUIUrl: "/iotstudio/settings/statesets", EditUIUrl: "/iotstudio/settings/stateset/{id}", CreateUIUrl: "/iotstudio/settings/stateset/add")]
    public class StateSet : IoTModelBase, IValidateable, IFormDescriptor, ILockable, ISummaryFactory, IIconEntity, ICategorized
    {
        public StateSet()
        {
            States = new List<State>();
            Id = Guid.NewGuid().ToId();
            Icon = "icon-ae-checklist-1";
        }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateSet_IsLocked, HelpResource: DeviceLibraryResources.Names.StateSet_IsLocked_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsLocked { get; set; }

        public EntityHeader LockedBy { get; set; }

        public String LockedDateStamp { get; set; }


        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(DeviceLibraryResources))]
        public string Icon { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateSet_States, FactoryUrl: "/api/statemachine/factory/state", FieldType: FieldTypes.ChildListInline, ResourceType: typeof(DeviceLibraryResources))]
        public List<State> States { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_RequireEnum, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_RequireEnum_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool RequireEnum { get; set; }

        public StateSetSummary CreateSummary()
        {
            return new StateSetSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                IsLocked = IsLocked,
                Name = Name,
                Icon = Icon,
                Description = Description,
                Category = Category?.Text,
                CategoryKey = Category?.Key,
                CategoryId = Category?.Id
            };
        }

        [CustomValidator]
        public void Validate(ValidationResult result)
        {
            if (States.Count() < 2)
            {
                result.AddUserError("State Sets require at least 2 States.");
            }
            else
            {
                if (States.Select(state => state.Key).Distinct().Count() != States.Count()) result.AddUserError("Duplicate Keys found on States.");
                if (States.Where(state => state.IsInitialState).Count() == 0) result.AddUserError("Could not find initial state on State Set.  Please add one.");
                if (States.Where(state => state.IsInitialState).Count() > 1) result.AddUserError("Found multiple Initial States on State Set.  Please ensure you have only one.");
            }

            if (RequireEnum)
            {
                if (States.Where(state => !state.EnumValue.HasValue).Any())
                {
                    result.AddUserError("This State requires that each state has an enumeration value, but not all do.");
                }
                else if (States.Select(state => state.EnumValue.Value).Distinct().Count() != States.Count())
                {
                    result.AddUserError("Enum values on States must be Unique.");
                }
            }
        }

        public StateSet Clone(bool newId = false, EntityHeader org = null, EntityHeader user = null)
        {
            var stateSet = new StateSet()
            {
                CreatedBy = CreatedBy.Clone(),
                LastUpdatedBy = LastUpdatedBy.Clone(),
                OwnerOrganization = OwnerOrganization.Clone(),

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
                LockedBy = LockedBy.Clone(),
                LockedDateStamp = LockedDateStamp,
                Name = Name,
                OwnerUser = OwnerUser.Clone(),
                RequireEnum = RequireEnum,
            };

            if (OwnerUser != null)
            {
                stateSet.OwnerUser = user == null ? OwnerUser.Clone() : user;
            }

            if (IsLocked)
            {
                stateSet.LockedBy = user == null ? LockedBy.Clone() : user;
            }


            foreach (var state in States)
            {
                stateSet.States.Add(state.Clone());
            }

            return stateSet;
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(StateSet.Name),
                nameof(StateSet.Key),
                nameof(StateSet.Icon),
                nameof(StateSet.Category),
                nameof(StateSet.Description),
                nameof(StateSet.RequireEnum),
                nameof(StateSet.IsLocked),
                nameof(StateSet.States),
            };
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.StateSet_Title, Resources.DeviceLibraryResources.Names.StateSet_Help,
      Resources.DeviceLibraryResources.Names.StateSet_Description, EntityDescriptionAttribute.EntityTypes.Summary, ResourceType: typeof(DeviceLibraryResources), Icon: "icon-ae-checklist-1",
      DeleteUrl: "/api/statemachine/stateset/{id}", SaveUrl: "/api/statemachine/stateset", GetListUrl: "/api/statemachine/statesets", GetUrl: "/api/statemachine/stateset/{id}", FactoryUrl: "/api/statemachine/factory/stateset")]
    public class StateSetSummary : SummaryData
    {
        public bool IsLocked {get; set;}
    }
}
