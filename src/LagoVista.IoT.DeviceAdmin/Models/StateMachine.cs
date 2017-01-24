using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.StateMachine_Title, Resources.DeviceLibraryResources.Names.StateMachine_UserHelp, Resources.DeviceLibraryResources.Names.StateMachine_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class StateMachine : DeviceModelBase, IOwnedEntity, IKeyedEntity
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_InitialState, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader InitialState { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.StateMachine_Initialization_Actions, HelpResource: DeviceLibraryResources.Names.StateMachine_Initialization_Actions_Help, FieldType:FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<EntityHeader> InitialActions {get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_States, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_States, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<State> States { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Variables, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_Variables_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<CustomField> Variables { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Events, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_Events_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<StateMachineEvent> Events { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Exception_OnInvalidEvent, FieldType: FieldTypes.Bool, HelpResource:DeviceLibraryResources.Names.StateMachine_Exception_OnInvalidEvent_Help, ResourceType: typeof(DeviceLibraryResources))]
        public bool ExceptionOnUnhandledEvent { get; set; }

        public StateMachineSummary CreateSummary()
        {
            return new StateMachineSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Name = Name,
                Key = Key
            };
        }
    }

    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.StateMachine_Title, Resources.DeviceLibraryResources.Names.StateMachine_UserHelp, Resources.DeviceLibraryResources.Names.StateMachine_Description, EntityDescriptionAttribute.EntityTypes.Summary, typeof(DeviceLibraryResources))]
    public class StateMachineSummary
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, IsUserEditable: false, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsUserEditable: false)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, IsUserEditable: false, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }
    }

}
