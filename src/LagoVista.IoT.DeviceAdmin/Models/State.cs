using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, Resources.DeviceLibraryResources.Names.State_Title, Resources.DeviceLibraryResources.Names.State_UserHelp, Resources.DeviceLibraryResources.Names.State_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class State : IKeyedEntity
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_TransitionInAction, HelpResource: DeviceLibraryResources.Names.StateMachine_State_TransitionInAction_Help, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public Action TransitionInAction { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Transitions, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_State_Transitions_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public ObservableCollection<StateTransition> Transitions { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }

        public Point DiagramLocation { get; set; }
    }
}
