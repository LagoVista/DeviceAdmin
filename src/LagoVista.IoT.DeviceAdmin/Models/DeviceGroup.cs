using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class DeviceGroup : TableStorageEntity
    {
        public String DeviceId { get; set; }
        public String DeviceName { get; set; }        
        public String DeviceGroupId { get; set; }
        public String DeviceGroupName { get; set; }
    }
}
