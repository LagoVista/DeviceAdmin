using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class DeviceReadings<TValueType>
    {
        public String Id { get; set; }
        public String DeviceId { get; set; }
        public String DateStamp { get; set; }
        public TValueType Value { get; set; }
        public String Units { get; set; }
    }
}
