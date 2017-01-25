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
    public class DeviceConfiguration : DeviceModelBase, IOwnedEntity, IValidateable, IKeyedEntity
    {
        public enum Environments
        {
            Development,
            Staging,
            Production
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfig_ConfigVersion, FieldType:FieldTypes.Decimal, IsRequired:true, ResourceType: typeof(DeviceLibraryResources))]
        public double ConfigurationVersion { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfig_Manufacture, ResourceType: typeof(DeviceLibraryResources))]
        public String Manufacture { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfig_Model, ResourceType: typeof(DeviceLibraryResources))]
        public String Model { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Environment, FieldType: FieldTypes.ChildItem, ResourceType: typeof(DeviceLibraryResources))]
        public EntityHeader Environment
        {
            get;
            set;
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

        public DeviceConfigurationSummary CreateSummary()
        {
            return new DeviceConfigurationSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Name = Name,
            };
        }

    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.DeviceConfiguration_Title, Resources.DeviceLibraryResources.Names.DeviceConfiguration_Help, Resources.DeviceLibraryResources.Names.DeviceConfiguration_Description, EntityDescriptionAttribute.EntityTypes.Summary, typeof(DeviceLibraryResources))]
    public class DeviceConfigurationSummary
    {
        [ListColumn(Visible:false)]
        public String Id { get; set; }

        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }

        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources))]
        public String Name { get; set; }

        [ListColumn(HeaderResource: Resources.DeviceLibraryResources.Names.Common_Key,  ResourceType: typeof(DeviceLibraryResources))]
        public String Key { get; set; }
    }
}
