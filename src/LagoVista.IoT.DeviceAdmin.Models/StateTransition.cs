using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.StateTransition_Title, 
        Resources.DeviceLibraryResources.Names.StateTransition_UserHelp, Resources.DeviceLibraryResources.Names.StateTransition_Description,
        EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources), FactoryUrl: "/api/statemachine/factory/transition")]
    public class StateTransition : IFormDescriptor
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Event,  FactoryUrl: "/api/statemachine/factory/event", IsUserEditable:false,
            HelpResource: DeviceLibraryResources.Names.StateMachine_Transition_EventHelp, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<Event> Event { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_NewState, FactoryUrl: "/api/statemachine/factory/state", IsUserEditable:false,
            HelpResource: DeviceLibraryResources.Names.StateMachine_NewState_Help, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader<State> NewState { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Transition_Script, ScriptTemplateName: "transitionAction", WaterMark: DeviceLibraryResources.Names.StateMachine_Transition_Script_Watermark,
            HelpResource: DeviceLibraryResources.Names.StateMachine_Transition_Action_Help, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public string TransitionAction { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public string Description { get; set; }

        public StateTransition Clone()
        {
            var trns = new StateTransition()
            {
                TransitionAction = TransitionAction,
                Description = Description,
            };

            if (!EntityHeader.IsNullOrEmpty(Event))
            {
                trns.Event = new EntityHeader<Event>()
                {
                    Id = Event.Id,
                    Text = Event.Text,
                };

                if (Event.Value != null)
                {
                    trns.Event.Value = Event.Value.Clone();
                }
            }
        
            if (!EntityHeader.IsNullOrEmpty(NewState))
            {
                trns.NewState = new EntityHeader<State>()
                {
                    Id = NewState.Id,
                    Text = NewState.Text,
                };

                if(NewState.Value != null)
                {
                    trns.NewState.Value = NewState.Value.Clone();
                }
            }

            return trns;
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Event),
                nameof(NewState),
                nameof(TransitionAction),
                nameof(Description)
            };
        }
    }
}