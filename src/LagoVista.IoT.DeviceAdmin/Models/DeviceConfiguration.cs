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
    public class DeviceConfiguration : DeviceModelBase, IOwnedEntity, IValidateable, IKeyedEntity, INoSQLEntity
    {
        public DeviceConfiguration()
        {
            
        }

        public String DatabaseName { get; set; }

        public String EntityType { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceConfiguration_Version, FieldType:FieldTypes.Decimal, IsRequired:true, ResourceType: typeof(DeviceLibraryResources))]
        public double ConfigurationVersion { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }


        public IConnectionSettings DeviceStorageConnectionSettings { get; set; }
        public IConnectionSettings DeviceArchiveConnectionSettings { get; set; }
        public IConnectionSettings QueueSettings { get; set; }
        public IConnectionSettings LoggerSettings { get; set; }
        

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }
        
        public EntityHeader ToEntityHeader()
        {
            return new EntityHeader()
            {
                Id = Id,
                Text = Name,
            };
        }

        public DevicePipelineModuleConfiguration<ListenerConfiguration> Listener { get; set; }
        public DevicePipelineModuleConfiguration<SentinalConfiguration> Sentinal { get; set; }
        public DevicePipelineModuleConfiguration<InputTranslatorConfiguration> InputTranslator { get; set; }
        public DevicePipelineModuleConfiguration<DeviceWorkflow> DeviceWorkflow { get; set; }
        public DevicePipelineModuleConfiguration<OutputTranslatorConfiguration> OutputTranslator { get; set; }
        public DevicePipelineModuleConfiguration<TransmitterConfiguration> Transmitter { get; set; }

        public List<DevicePipelineModuleConfiguration<CustomPipelineModuleConfiguration>> CustomPipelineModuleConfigurations { get; set; }


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
                Key = Key,
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