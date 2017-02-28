using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public abstract class NodeBase : KeyOwnedDeviceAdminBase
    {
        public NodeBase()
        {
            OutgoingConnections = new ObservableCollection<Connection>();
            IncomingConnections = new ObservableCollection<Connection>();
            DiagramLocations = new ObservableCollection<DiagramLocation>();
        }


        public ObservableCollection<Connection> OutgoingConnections { get; set; }
        public ObservableCollection<Connection> IncomingConnections { get; set; }


        public ObservableCollection<DiagramLocation> DiagramLocations { get; set; }
    }
}
