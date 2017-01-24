using LagoVista.Core.Attributes;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(DeviceAdminDomain.DeviceAdmin, Resources.DeviceLibraryResources.Names.Environment, Resources.DeviceLibraryResources.Names.Environment_Help, Resources.DeviceLibraryResources.Names.Environment_Help, EntityDescriptionAttribute.EntityTypes.SimpleModel, typeof(DeviceLibraryResources))]
    public class Environment
    {
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_IsPublic, FieldType: FieldTypes.Bool, ResourceType: typeof(DeviceLibraryResources))]
        public bool IsPublic { get; set; }


        public EntityHeader OwnerOrganization { get; set; }


        [JsonProperty("id")]
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_UniqueId, IsUserEditable: false, ResourceType: typeof(DeviceLibraryResources), IsRequired: true)]
        public String Id { get; set; }


        private String _name;
        [FormField(LabelResource: Resources.DeviceLibraryResources.Names.Common_Name, ResourceType: typeof(DeviceLibraryResources), IsRequired: true, IsUserEditable: true)]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public static List<Environment> GetStandardList()
        {
            var environments = new List<Environment>();
            environments.Add(new Environment()
            {
                Id = "7A84A4B9289544D0BA28C9BAD9223ACD",
                IsPublic = true, 
                Name = Resources.DeviceLibraryResources.Environment_Dev
            });

            environments.Add(new Environment()
            {
                Id = "18BCDEA988184F4485467550581F6836",
                IsPublic = true,
                Name = Resources.DeviceLibraryResources.Environment_Test
            });

            environments.Add(new Environment()
            {
                Id = "87EB2BBD3A6041CFB3B7E737220249FE",
                IsPublic = true,
                Name = Resources.DeviceLibraryResources.Environment_Production
            });


            return environments;
        }

        public EntityHeader ToEntityHeader()
        {
            return new EntityHeader()
            {
                Id = Id,
                Text = Name
            };
        }

        public static Environment GetDefault()
        {
            return new Environment()
            {
                Id = "7A84A4B9289544D0BA28C9BAD9223ACD",
                IsPublic = true,
                Name = Resources.DeviceLibraryResources.Environment_Dev
            };
        }
    }
}
