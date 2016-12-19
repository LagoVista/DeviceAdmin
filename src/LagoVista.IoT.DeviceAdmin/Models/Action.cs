using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Title:DeviceLibraryResources.Names.Action_Title, Domain:DeviceAdminDomain.DeviceAdmin, Description: DeviceLibraryResources.Names.Action_Description, UserHelp:DeviceLibraryResources.Names.Action_Help, ResourceType: typeof(DeviceLibraryResources) )]
    public class Action : DeviceModelBase, IKeyedEntity
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_Shared, HelpResource: Resources.DeviceLibraryResources.Names.Action_Standard_Help, FieldType: FieldTypes.ChildItem, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public SharedAction SharedAction { get; set; }
   

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_Script, HelpResource: Resources.DeviceLibraryResources.Names.Action_ExecuteFromScript_Help, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Script { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Key { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_ExecuteFromScript, HelpResource: Resources.DeviceLibraryResources.Names.Action_ExecuteFromScript_Help, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public bool ExecuteFromScript { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_ExecuteFromPost, HelpResource: Resources.DeviceLibraryResources.Names.Action_ExecuteFromPost_Help, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public bool ExecuteFromPost { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_ExecuteFromGet, HelpResource: Resources.DeviceLibraryResources.Names.Action_ExecuteFromGet_Help, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public bool ExecuteFromGet { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_ExecuteFromStateMachine, HelpResource: Resources.DeviceLibraryResources.Names.Action_ExecuteFromstateMachine_Help, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public bool ExecuteFromStateMachine { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_Parameters, HelpResource: Resources.DeviceLibraryResources.Names.Action_Parameters, FieldType: FieldTypes.Text, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public List<ActionParameter> Parameters { get; set; }
      
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_AssociatedAttribute, HelpResource: Resources.DeviceLibraryResources.Names.Action_AssociatedAttribute_Help, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public Attribute AssociatedAttribute { set; get; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_RemoteUri, HelpResource: Resources.DeviceLibraryResources.Names.Action_RemoteUri, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String ActionRemoteURI { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Action_NodeRedFlows, HelpResource: Resources.DeviceLibraryResources.Names.Action_NodeRedFlows, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public List<NodeRedFlow> NodeRedFlows { get; set; }
    }
}
