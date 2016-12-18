using LagoVista.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [DomainDescriptor]
    public class DeviceAdminDomain
    {
        //[DomainDescription(Name: "Device Admin", Description: "Models for working with and creating device configurations.  This includes things such as actions, attributes and state machines.")]
        public const string DeviceAdmin = "DeviceAdmin";

      //  [DomainDescription(Name: "State Machines", Description: "State Machines are used for a number of system level components.")]
        public const string StateMachines = "StateMachine";
    }
}
