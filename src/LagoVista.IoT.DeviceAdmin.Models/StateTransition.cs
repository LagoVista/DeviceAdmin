﻿using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.StateTransition_Title, Resources.DeviceLibraryResources.Names.StateTransition_UserHelp, Resources.DeviceLibraryResources.Names.StateTransition_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class StateTransition
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Event, HelpResource: DeviceLibraryResources.Names.StateMachine_Transition_EventHelp, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<Event> Event { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_NewState, HelpResource: DeviceLibraryResources.Names.StateMachine_NewState_Help, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<State> NewState { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Transition_Script, HelpResource: DeviceLibraryResources.Names.StateMachine_Transition_Action_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public string TransitionAction { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }
    }
}