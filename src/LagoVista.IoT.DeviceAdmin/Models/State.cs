using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Title: Resources.DeviceLibraryResources.Names.State_Title, Domain: DeviceAdminDomain.DeviceAdmin, UserHelp: Resources.DeviceLibraryResources.Names.State_UserHelp, Description: Resources.DeviceLibraryResources.Names.State_Description, ResourceType: typeof(DeviceLibraryResources))]
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
