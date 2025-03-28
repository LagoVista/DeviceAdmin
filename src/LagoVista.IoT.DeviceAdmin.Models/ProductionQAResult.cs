using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class ProductionQAResult
    {
        public EntityHeader DeviceType { get; set; }
        public EntityHeader CheckedBy { get; set; }
        public EntityHeader OwnerOrganization { get; set; }
        public int SerialNumber { get; set; }
        public string TimeStamp { get; set; }
        public string Notes { get; set; }
        public string DeviceUniqueId { get; set; }

        public EntityHeader Location { get; set; }
        public EntityHeader Room { get; set; }
        public EntityHeader ShelfUnit { get; set; }
        public EntityHeader Shelf { get; set; }
        public EntityHeader Column { get; set; }
        public EntityHeader Customer { get; set; }
    }
}
