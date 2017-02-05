using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.SharedAction_Title, Resources.DeviceLibraryResources.Names.SharedAction_Help, Resources.DeviceLibraryResources.Names.SharedAction_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class SharedAction : DeviceModelBase, IOwnedEntity, IValidateable, INoSQLEntity
    {
        public String DatabaseName { get; set; }

        public String EntityType { get; set; }


        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }

        public Action Action { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        public SharedActionSummary CreateSummary()
        {
            return new SharedActionSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Name = Name,
                Key = Key,
            };
        }
    }

    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.SharedAction_Title, Resources.DeviceLibraryResources.Names.SharedAction_Help, Resources.DeviceLibraryResources.Names.SharedAction_Description, EntityDescriptionAttribute.EntityTypes.Summary, typeof(DeviceLibraryResources))]
    public class SharedActionSummary
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, IsUserEditable: false, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsUserEditable: false)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, IsUserEditable: false, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }
    }
}
