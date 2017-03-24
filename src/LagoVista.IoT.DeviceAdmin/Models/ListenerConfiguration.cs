using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class ListenerConfiguration : PipelineModuleConfiguration
    {
        public enum ListnerTypes
        {
            Rest,
            Soap,
            RawTCP,
            RawUDP,
            AMQP,
            MQTT,
            Custom
        }

        public ListnerTypes ListenerType { get; set; }

        public int Port { get; set; }

        public bool DelimitedWithSOHEOT { get; set; }

        public string Endpoint { get; set; }

        public bool KeepAliveToSendAck { get; set; }

        public int KeepAliveToSendAckTimeoutMS { get; set; }

        public string StartMessageSequence { get; set; }

        public string EndMessageSequence { get; set; }

        public int? MessageReceiveTimeoutMS { get; set; }

        public int? MaxMessageSize { get; set; }
    }
}
