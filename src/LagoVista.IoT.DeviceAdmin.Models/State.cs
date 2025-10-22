// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: b7e781c3646e6b2c5be01277eab59a1a1cc0c3342bc0ffe4e31306e2ac667119
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.State_Title, Resources.DeviceLibraryResources.Names.State_UserHelp, Resources.DeviceLibraryResources.Names.State_Description,
        EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources), FactoryUrl: "/api/statemachine/factory/state")]
    public class State : IKeyedEntity, IFormDescriptor
    {
        public State()
        {
            DiagramLocations = new ObservableCollection<Models.DiagramLocation>();
            Transitions = new ObservableCollection<StateTransition>();
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_TransitionInAction, HelpResource: DeviceLibraryResources.Names.StateMachine_State_TransitionInAction_Help,
          ScriptTemplateName: "stateTransitionInAction",  WaterMark:DeviceLibraryResources.Names.State_TransitionInAction_Watermark, FieldType: FieldTypes.NodeScript, ResourceType: typeof(DeviceLibraryResources))]
        public String TransitionInAction { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Text, ValidationRegEx: "^[a-z0-9]{2,20}$", RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Key_RegEx, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Enum, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Enum_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources))]
        public int? EnumValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_IsInitialState, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_State_IsInitialState_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsInitialState { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.State_IsAlarmState, HelpResource: Resources.DeviceLibraryResources.Names.State_IsAlarmState_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsAlarmState { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.State_ErrorCode, HelpResource: Resources.DeviceLibraryResources.Names.State_ErrorCode_Help, 
            WaterMark:Resources.DeviceLibraryResources.Names.State_ErrorCode_Select, FactoryUrl:"/api/errorcode/factory",
            EntityHeaderPickerUrl: "/api/errorcodes", FieldType: FieldTypes.EntityHeaderPicker, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader ErrorCode { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Transitions, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Transitions_Help, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<StateTransition> Transitions { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }

        public ObservableCollection<DiagramLocation> DiagramLocations { get; set; }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(State.Name),
                nameof(State.Key),
                nameof(State.IsInitialState),
                nameof(State.IsAlarmState),
                nameof(State.ErrorCode),
                nameof(State.EnumValue),
                nameof(State.Description),
                nameof(State.TransitionInAction),
            };
        }

        public State Clone()
        {
            var state = new State()
            {
                Description = Description,
                EnumValue = EnumValue,
                IsInitialState = IsInitialState,
                IsAlarmState = IsAlarmState,
                ErrorCode = ErrorCode,
                Name = Name,
                Key = Key,
                TransitionInAction = TransitionInAction,
            };

            foreach(var trns in Transitions)
            {
                Transitions.Add(trns.Clone());
            }

            foreach(var dgl in DiagramLocations)
            {
                DiagramLocations.Add(dgl.Clone());
            }

            return state;
        }

        public void Validate(ValidationResult result)
        {

        }
    }
}
