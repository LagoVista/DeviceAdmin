using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Title: Resources.DeviceLibraryResources.Names.StateMachineEvent_Title, Domain: DeviceAdminDomain.DeviceAdmin, UserHelp: Resources.DeviceLibraryResources.Names.StateMachineEvent_UserHelp, Description: Resources.DeviceLibraryResources.Names.StateMachineEvent_Description, ResourceType: typeof(DeviceLibraryResources))]
    public class StateMachineEvent : IKeyedEntity, INamedEntity
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: false)]
        public String Name { get; set; }
        

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }
    }
}
