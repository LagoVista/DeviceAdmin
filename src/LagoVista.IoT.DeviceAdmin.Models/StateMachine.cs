﻿using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.StateMachine_Title, Resources.DeviceLibraryResources.Names.StateMachine_UserHelp, Resources.DeviceLibraryResources.Names.StateMachine_Description,
        EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources), Icon: "icon-fo-globe-2",
         FactoryUrl: "/api/statemachine/factory", GetUrl: "/api/statemachine/{id}", GetListUrl: "/api/statemachines", SaveUrl: "/api/statemachine", DeleteUrl: "/api/statemachine/{id}")]
    public class StateMachine : NodeBase, IValidateable, ISummaryFactory, IFormDescriptor
    {        
        public StateMachine()
        {
            States = new ObservableCollection<State>();
            Events = new ObservableCollection<Event>();
            Variables = new ObservableCollection<Parameter>();
            InitialActions = new ObservableCollection<EntityHeader>();
            Pages = new ObservableCollection<Page>();
            Icon = "icon-fo-globe-2";
        }
    
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_InitialState, FieldType: FieldTypes.Text, IsUserEditable:false, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader InitialState { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.StateMachine_Initialization_Actions, 
            HelpResource: DeviceLibraryResources.Names.StateMachine_Initialization_Actions_Help, 
            FieldType:FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<EntityHeader> InitialActions {get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.Common_Icon, FieldType: FieldTypes.Icon, ResourceType: typeof(DeviceLibraryResources))]
        public string Icon { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_States, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_States, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<State> States { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Variables, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_Variables_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<Parameter> Variables { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Events, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_Events_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<Event> Events { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Exception_OnInvalidEvent, FieldType: FieldTypes.CheckBox, HelpResource:DeviceLibraryResources.Names.StateMachine_Exception_OnInvalidEvent_Help, ResourceType: typeof(DeviceLibraryResources))]
        public bool ExceptionOnUnhandledEvent { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Pages, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_Pages_Help, ResourceType: typeof(DeviceLibraryResources), FieldType: FieldTypes.ChildList)]
        public ObservableCollection<Page> Pages { get; set; }

        public override string NodeType => NodeType_StateMachine;

        public StateMachineSummary CreateSummary()
        {
            return new StateMachineSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Name = Name,
                Icon = Icon,
                Key = Key,
                Description = Description
            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
                nameof(Name),
                nameof(Key),
                nameof(Icon),
                nameof(ExceptionOnUnhandledEvent),
                nameof(Description)
            };
        }

        public void Validate(DeviceWorkflow workflow, ValidationResult result)
        {
            if (Validator.Validate(this).Successful)
            {
                if (States.Select(param => param.Key).Distinct().Count() != States.Count()) result.AddUserError($"Duplicate Keys found in States on State Machine: {Name}.");
                if (Events.Select(param => param.Key).Distinct().Count() != Events.Count()) result.AddUserError($"Duplicate Keys found in Events on State Machine: {Name}.");
                if (Variables.Select(param => param.Key).Distinct().Count() != Variables.Count()) result.AddUserError($"Duplicate Keys found in Variables on State Machine: {Name}.");

                result.Concat(ValidateNodeBase(workflow));
                foreach (var connection in OutgoingConnections)
                {
                    if (connection.NodeType == NodeType_Input || connection.NodeType == NodeType_InputCommand)
                    {
                        result.Errors.Add(new ErrorMessage($"Mapping from an Input to a node of type: {NodeType} is not supported", true));
                    }
                }

                foreach (var variable in Variables)
                {
                    variable.Validate(result);
                }

                foreach (var state in States)
                {
                    state.Validate(result);
                }
            }
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.StateMachine_Title, Resources.DeviceLibraryResources.Names.StateMachine_UserHelp, 
        Resources.DeviceLibraryResources.Names.StateMachine_Description, EntityDescriptionAttribute.EntityTypes.Summary, typeof(DeviceLibraryResources),
        FactoryUrl: "/api/statemachine/factory", GetUrl: "/api/statemachine/{id}", GetListUrl: "/api/statemachines", SaveUrl: "/api/statemachine", DeleteUrl: "/api/statemachine/{id}")]
    public class StateMachineSummary : SummaryData
    {
    }
}
