using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    /// <summary>
    /// An attribute category is used to define a specific type of attribute so it can
    /// be used across different devices.  An example of this is would On/Off
    /// 
    /// From a programming perspective you can think of an Attribute Category as
    /// an interface of which properties the attribute impleements.
    /// 
    /// The Attribute itself can have up to one attribute category
    /// attached to it.
    /// </summary>
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, DeviceLibraryResources.Names.SharedAttribute_Title,  Resources.DeviceLibraryResources.Names.SharedAttribute_Help, DeviceLibraryResources.Names.SharedAttribute_Description, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class SharedAttribute : DeviceModelBase, IOwnedEntity, IKeyedEntity, IValidateable
    {
        public bool IsPublic { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public EntityHeader OwnerUser { get; set; }

        public UnitSet UnitSet { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }

        public SharedAttributeSummary CreateSummary()
        {
            return new SharedAttributeSummary()
            {
                Id = Id,
                IsPublic = IsPublic,
                Name = Name,
                Key = Key,
            };
        }
    }


    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.SharedAttribute_Title, Resources.DeviceLibraryResources.Names.SharedAction_Help, Resources.DeviceLibraryResources.Names.SharedAction_Description, EntityDescriptionAttribute.EntityTypes.Summary, typeof(DeviceLibraryResources))]
    public class SharedAttributeSummary
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, IsUserEditable:false, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsUserEditable: false)]
        public String Name { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Key, IsUserEditable:false, HelpResource: Resources.DeviceLibraryResources.Names.Common_Key_Help, FieldType: FieldTypes.Key, RegExValidationMessageResource: Resources.DeviceLibraryResources.Names.Common_Key_Validation, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Key { get; set; }
    }
}
