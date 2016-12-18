using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Name:"State Transition", Domain:DeviceAdminDomain.StateMachines, Description:"A State Transition can be added to a State.  A Transition is a Definition of an Event that can be handled, an Action to be Executed and a New State that the State Machine will be in after the event is handled.  Note that it is possible that the state may remain the same and the event will be used to only execute an action.")]
    public class StateTransitions
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Event, HelpResource: DeviceLibraryResources.Names.StateMachine_Transition_EventHelp, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public IEntityHeader Event { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_NewState, HelpResource: DeviceLibraryResources.Names.StateMachine_NewState_Help, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public IEntityHeader NewState { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Transition_Action, HelpResource: DeviceLibraryResources.Names.StateMachine_Transition_Action_Help, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public IEnumerable<IEntityHeader> TransitionActions { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }
    }
}
