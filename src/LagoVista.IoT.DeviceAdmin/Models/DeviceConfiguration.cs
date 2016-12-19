using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using LagoVista.Core;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.UserManagement.Models.Account;
using LagoVista.Core.Interfaces;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.DeviceConfiguration_Title, Resources.DeviceLibraryResources.Names.DeviceConfiguration_Help,  Resources.DeviceLibraryResources.Names.DeviceConfiguration_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class DeviceConfiguration : DeviceModelBase, IOwnedEntity, IValidateable
    {
        public enum Environments
        {
            Development,
            Staging,
            Production
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfig_ConfigVersion, ResourceType: typeof(DeviceLibraryResources))]
        public String ConfigurationVersion { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfig_Manufacture, ResourceType: typeof(DeviceLibraryResources))]
        public String Manufacture { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfig_Model, ResourceType: typeof(DeviceLibraryResources))]
        public String Model { get; set; }


        public Environments Environment
        {
            get;set;
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfig_Attributes, HelpResource:DeviceLibraryResources.Names.DeviceConfig_Attributes_Help, ResourceType: typeof(DeviceLibraryResources))]
        public List<Models.Attribute> Attributes { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfig_Actions, HelpResource:DeviceLibraryResources.Names.DeviceConfig_Actions_Help, ResourceType: typeof(DeviceLibraryResources))]
        public List<Models.Action> Actions { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfig_CustomFields, ResourceType: typeof(DeviceLibraryResources))]
        public List<Models.CustomField> CustomFields { get; set; }

        public EntityHeader ToEntityHeader()
        {
            return new EntityHeader()
            {
                Id = Id,
                Text = Name,
            };
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.StateMachines, ResourceType: typeof(DeviceLibraryResources))]
        public List<StateMachine> StateMachines
        {
            get; set; 
        }        

        public static DeviceConfiguration Create(Organization org, AppUser appUser)
        {
            return new DeviceConfiguration()
            {
                Id = Guid.NewGuid().ToId(),
                CreatedBy = appUser.ToEntityHeader(),
                CreationDate = DateTime.Now.ToJSONString(),
                LastUpdatedBy = appUser.ToEntityHeader(),
                LastUpdatedDate = DateTime.Now.ToJSONString(),
                OwnerOrganization = org.ToEntityHeader(),
            };
        }
    }
}
