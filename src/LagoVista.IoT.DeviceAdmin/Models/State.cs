using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Name:"State", Domain:DeviceAdminDomain.StateMachines, Description:"A State is a conceptual entity that a Device Configuration, Attribute or other mechanism can be in.  The state machine can only be in exactly one state at a given time, an action is used to transition the state into another state and optionally perform an action at that time.")]
    public class State : IKeyedEntity
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_State_TransitionInAction, HelpResource:DeviceLibraryResources.Names.StateMachine_State_TransitionInAction_Help, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public Action TransitionInAction { get; set; } 

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources))]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }
    }
}
