using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.StateTransition_Title, Resources.DeviceLibraryResources.Names.StateTransition_UserHelp, Resources.DeviceLibraryResources.Names.StateTransition_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class StateTransition
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