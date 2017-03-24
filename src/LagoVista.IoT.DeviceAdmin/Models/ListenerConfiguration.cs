using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class ListenerConfiguration : PipelineModuleConfiguration
    {
        public int Port { get; set; }

        public string Endpoint { get; set; }
    }
}
