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

        public const string NodeType_Input = "workflowinput";
        public const string NodeType_Attribute = "attribute";
        public const string NodeType_Action = "action";
        public const string NodeType_InputCommand = "inputcommand";
        public const string NodeType_Timer = "timer";
        public const string NodeType_StateMachine = "statemachine";
        public const string NodeType_OutputCommand = "outputcommand";

        public abstract string NodeType { get; }

        public ObservableCollection<Connection> OutgoingConnections { get; set; }
        public ObservableCollection<Connection> IncomingConnections { get; set; }

        public ObservableCollection<DiagramLocation> DiagramLocations { get; set; }
    }
}
