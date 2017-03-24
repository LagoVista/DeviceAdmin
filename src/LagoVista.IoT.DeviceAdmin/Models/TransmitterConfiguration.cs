using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class TransmitterConfiguration : PipelineModuleConfiguration
    {
        public enum TransmitterTypes
        {
            Rest,
            Soap,
            RawTCP,
            RawUDP,
            AMQP,
            MQTT,
            MailBox,
            Custom
        }

        public TransmitterTypes ListenerType { get; set; }

        public String Script { get; set; }    
    }
}