using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class Connection
    {
        public String DestinationKey { get; set; }
        public String DestinationName { get; set; }
        public String DestinationType { get; set; }
        public String Script { get; set; }

    }
}
