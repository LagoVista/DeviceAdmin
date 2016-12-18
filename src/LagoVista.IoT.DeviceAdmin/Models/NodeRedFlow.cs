using LagoVista.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    [EntityDescription(Name:"Node Red Flow", Description:"A Node Red Flow can be configured as part of an action to perform more complicated work flows and steps.", Domain:DeviceAdminDomain.DeviceAdmin)]
    public class NodeRedFlow
    {
        public String NodeRedFlowId { get; set; }
        public String Uri { get; set; }
    }
}
