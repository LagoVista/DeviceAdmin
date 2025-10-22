// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 42e99fc60d7676cb4efe73a63638d4178227d0739304cc1b184e60299a31f760
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models.Resources;
using System;
using System.Collections.Generic;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.EventSet_Title, Resources.DeviceLibraryResources.Names.EventSet_Help, Resources.DeviceLibraryResources.Names.EventSet_Description, 
        EntityDescriptionAttribute.EntityTypes.SimpleModel, ResourceType: typeof(DeviceLibraryResources),
        GetUrl: "/api/statemachine/eventset/{id}", GetListUrl: "/api/statemachine/eventsets", SaveUrl: "/api/statemachine/eventset", DeleteUrl: "/api/statemachine/eventset/{id}", FactoryUrl: "/api/statemachine/factory/eventset")]
    public class EventSet : IoTModelBase, IValidateable, ISummaryFactory
    {
        public EventSet()
        {
            Events = new List<Event>();
        }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.EventSet_IsLocked, HelpResource: DeviceLibraryResources.Names.EventSet_IsLocked_Help, FieldType: FieldTypes.CheckBox, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsLocked { get; set; }

        public EntityHeader LockedBy { get; set; }

        public String LockedDateStamp { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.EventSet_Events, FieldType: FieldTypes.ChildList, ResourceType: typeof(DeviceLibraryResources))]
        public List<Event> Events { get; set; }

        public EventSetSummary CreateSummary()
        {
            return new EventSetSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Key = Key,
                Name = Name,
            };
        }

        Core.Interfaces.ISummaryData ISummaryFactory.CreateSummary()
        {
            return CreateSummary();
        }
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.EventSet_Title, Resources.DeviceLibraryResources.Names.EventSet_Help, Resources.DeviceLibraryResources.Names.EventSet_Description,
        EntityDescriptionAttribute.EntityTypes.Summary, ResourceType: typeof(DeviceLibraryResources),
        GetUrl: "/api/statemachine/eventset/{id}", GetListUrl: "/api/statemachine/eventsets", SaveUrl: "/api/statemachine/eventset", DeleteUrl: "/api/statemachine/eventset/{id}", FactoryUrl: "/api/statemachine/factory/eventset")]
    public class EventSetSummary : SummaryData
    {
    }
}
