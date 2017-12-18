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
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.StateSet_Title, Resources.DeviceLibraryResources.Names.StateSet_Help, Resources.DeviceLibraryResources.Names.StateSet_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources))]
    public class StateSet : KeyOwnedDeviceAdminBase, IValidateable, INoSQLEntity, IOwnedEntity, IFormDescriptor, ILockable
    {
        public StateSet()
        {
            States = new List<State>();
            Id = Guid.NewGuid().ToId();
        }

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateSet_IsLocked, HelpResource: DeviceLibraryResources.Names.StateSet_IsLocked_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsLocked { get; set; }

        public EntityHeader LockedBy { get; set; }

        public String LockedDateStamp { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateSet_States, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<State> States { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_RequireEnum, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_RequireEnum_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool RequireEnum { get; set; }

        public StateSetSummary CreateStateSetSummary()
        {
            return new StateSetSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                Name = Name,
                Description = Description
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

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(StateSet.Name),
                nameof(StateSet.Key),
                nameof(StateSet.Description),
                nameof(StateSet.RequireEnum),
                nameof(StateSet.IsLocked),
                nameof(StateSet.States),
            };
        }
    }

    public class StateSetSummary : SummaryData, ISummaryData
    {
    }
}
