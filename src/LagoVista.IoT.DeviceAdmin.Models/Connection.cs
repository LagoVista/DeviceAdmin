// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 28a8284cb7aab14f00bf4082a2686744aa542f939bd6916be3619ee0ff1988d4
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Models;
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
        public String Script { get; set; }
        public EntityHeader<Event> StateMachineEvent { get; set; }
        public List<KeyValuePair<string, string>> Mappings { get; set; }
        public string InputCommandKey { get; set; }
    }
}
