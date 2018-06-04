using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.State_Title, Resources.DeviceLibraryResources.Names.State_UserHelp, Resources.DeviceLibraryResources.Names.State_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class State : IKeyedEntity, IFormDescriptor
    {
        public State()
        {
            DiagramLocations = new ObservableCollection<Models.DiagramLocation>();
            Transitions = new ObservableCollection<StateTransition>();
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_TransitionInAction, HelpResource: DeviceLibraryResources.Names.StateMachine_State_TransitionInAction_Help, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public String TransitionInAction { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Text, ValidationRegEx: "^[a-z0-9]{2,20}$", RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Key_RegEx, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Enum, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Enum_Help, FieldType: FieldTypes.Integer, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public int? EnumValue { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_IsInitialState, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_State_IsInitialState_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsInitialState { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Transitions, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Transitions_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
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
