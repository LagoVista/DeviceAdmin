using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Title: Resources.DeviceLibraryResources.Names.StateMachine_Title, Domain: DeviceAdminDomain.DeviceAdmin, UserHelp: Resources.DeviceLibraryResources.Names.StateMachine_UserHelp, Description: Resources.DeviceLibraryResources.Names.StateMachine_Description, ResourceType: typeof(DeviceLibraryResources))]
    public class StateMachine : DeviceModelBase, IOwnedEntity, IKeyedEntity
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_InitialState, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader InitialState { get; set; }

        [FormField(LabelResource: DeviceLibraryResources.Names.StateMachine_Initialization_Actions, HelpResource: DeviceLibraryResources.Names.StateMachine_Initialization_Actions_Help, FieldType:FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public IEnumerable<EntityHeader> InitialActions {get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_States, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_States, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public IEnumerable<State> States { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Variables, HelpResource: Resources.DeviceLibraryResources.Names.StateMachine_Variables_Help, FieldType: FieldTypes.Key, ResourceType: typeof(DeviceLibraryResources))]
        public IEnumerable<CustomField> Variables { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachine_Exception_OnInvalidEvent, FieldType: FieldTypes.Bool, HelpResource:DeviceLibraryResources.Names.StateMachine_Exception_OnInvalidEvent_Help, ResourceType: typeof(DeviceLibraryResources))]
        public bool ExceptionOnUnhandledEvent { get; set; }
    }
}
