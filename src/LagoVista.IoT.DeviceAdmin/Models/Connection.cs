using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class Connection
    {
        public String NodeKey { get; set; }
        public String NodeName { get; set; }
        public String NodeType { get; set; }
        // Look at for running the scripts https://github.com/sebastienros/jint
        public String Script { get; set; }

    }
}
