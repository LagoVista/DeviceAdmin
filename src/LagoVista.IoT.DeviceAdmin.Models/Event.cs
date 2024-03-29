﻿using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.StateMachines, DeviceLibraryResources.Names.StateMachineEvent_Title, Resources.DeviceLibraryResources.Names.StateMachineEvent_UserHelp,Resources.DeviceLibraryResources.Names.StateMachineEvent_Description, 
        EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources), FactoryUrl: "/api/statemachine/factory/event")]
    public class Event : IKeyedEntity, INamedEntity, IFormDescriptor
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, 
            FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Name { get; set; }
        

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Description, FieldType: FieldTypes.MultiLineText, ResourceType: typeof(DeviceLibraryResources))]
        public String Description { get; set; }

        public Event Clone()
        {
            return new Event()
            {
                Key = Key,
                Name = Name,
                Description = Description
            };
        }

        public List<string> GetFormFields()
        {
            return new List<string>()
            {
               nameof(Name),
               nameof(Key),
               nameof(Description),
            };
        }
    }
}
