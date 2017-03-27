using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.StateMachine_Title, Resources.DeviceLibraryResources.Names.StateMachine_UserHelp, Resources.DeviceLibraryResources.Names.StateMachine_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class StateMachine : NodeBase, IValidateable, INoSQLEntity
    {
        public String DatabaseName { get; set; }

        public String EntityType { get; set; }

        public StateMachine()
        {
            States = new ObservableCollection<State>();
            Events = new ObservableCollection<Event>();
            Variables = new ObservableCollection<CustomField>();
            InitialActions = new ObservableCollection<EntityHeader>();
            Pages = new ObservableCollection<Page>();
        }
    
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_InitialState, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader InitialState { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.StateMachine_Initialization_Actions, HelpResource: DeviceLibraryResources.Names.StateMachine_Initialization_Actions_Help, FieldType:FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<EntityHeader> InitialActions {get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_States, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_States, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<State> States { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Variables, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_Variables_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<CustomField> Variables { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Events, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_Events_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<Event> Events { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Exception_OnInvalidEvent, FieldType: FieldTypes.Bool, HelpResource:DeviceLibraryResources.Names.StateMachine_Exception_OnInvalidEvent_Help, ResourceType: typeof(DeviceLibraryResources))]
        public bool ExceptionOnUnhandledEvent { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Pages, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_Pages_Help, ResourceType: typeof(DeviceLibraryResources), FieldType: FieldTypes.ChildList)]
        public ObservableCollection<Page> Pages { get; set; }

        public StateMachineSummary CreateSummary()
        {
            return new StateMachineSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Name = Name,
                Key = Key,
                Description = Description
            };
        }
    }

    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.StateMachine_Title, Resources.DeviceLibraryResources.Names.StateMachine_UserHelp, Resources.DeviceLibraryResources.Names.StateMachine_Description, EntityDescriptionAttribute.EntityTypes.Summary, typeof(DeviceLibraryResources))]
    public class StateMachineSummary : SummaryData
    {
        
    }

}
