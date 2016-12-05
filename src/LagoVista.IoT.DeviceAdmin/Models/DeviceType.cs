using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;
using System.Collections.Generic;
using LagoVista.Core;
using LagoVista.UserManagement.Models.Orgs;
using LagoVista.UserManagement.Models.Account;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class DeviceType : DeviceModelBase, IValidateable
    {

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_Manufacture, ResourceType: typeof(DeviceLibraryResources))]
        public String Manufacture { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_Model, ResourceType: typeof(DeviceLibraryResources))]
        public String Model { get; set; }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_IsPublic, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }


        [FormField(LabelResource: LagoVista.UserManagement.Resources.UserManagementResources.Names.Organization, ResourceType: typeof(LagoVista.UserManagement.Resources.UserManagementResources), IsRequired: true, IsUserEditable: false)]
        public EntityHeader Account
        {
            get; set;
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_Capabilities, ResourceType: typeof(DeviceLibraryResources))]
        public List<Models.Attribute> Attributes { get; set; }


        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_CustomFields, ResourceType: typeof(DeviceLibraryResources))]
        public List<Models.CustomFields> CustomFields { get; set; }

        public EntityHeader ToEntityHeader()
        {
            return new EntityHeader()
            {
                Id = Id,
                Text = Name,
            };
        }

        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.DeviceType_States, ResourceType: typeof(DeviceLibraryResources))]
        public List<EntityHeader> States
        {
            get; set; 
        }        

        public static DeviceType Create(Organization account, AppUser appUser)
        {
            return new DeviceType()
            {
                Id = Guid.NewGuid().ToId(),
                CreatedBy = appUser.ToEntityHeader(),
                CreationDate = DateTime.Now.ToJSONString(),
                LastUpdatedBy = appUser.ToEntityHeader(),
                LastUpdatedDate = DateTime.Now.ToJSONString(),
                Account = account.ToEntityHeader(),
            };
        }
    }
}
