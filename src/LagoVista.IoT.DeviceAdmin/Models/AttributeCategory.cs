using LagoVista.Core.Models;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class AttributeCategory : TableStorageEntity
    {
        public bool IsPublic { get; set; }
        public String OrganizationId { get; set; }
        public String OrganizationName { get; set; }
        public String Name { get; set; }
        public String DefaultUnits { get; set; }
    }
}
