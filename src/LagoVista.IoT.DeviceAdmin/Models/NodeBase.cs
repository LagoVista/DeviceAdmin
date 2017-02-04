using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public abstract class NodeBase : KeyOwnedDeviceAdminBase
    {
        public NodeBase()
        {
            OutgoingConnections = new List<Connection>();
            IncomingConnections = new List<Connection>();
        }


        public List<Connection> OutgoingConnections { get; set; }
        public List<Connection> IncomingConnections { get; set; }


        public Point DiagramLocation { get; set; }
    }
}
