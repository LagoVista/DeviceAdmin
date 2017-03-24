using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class TransmitterConfiguration : PipelineModuleConfiguration
    {
        public enum TransmitterTypes
        {
            AzureServiceBus,
            AzureEventHub,
            AzureIoTHub,
            Rest,
            Soap,
            RawTCP,
            RawUDP,
            AMQP,
            MQTT,
            Outbox,
            SMTPServer,
            SMSTransmitter,
            OriginalListener,
            Custom
        }

        public TransmitterTypes ListenerType { get; set; }

        public String Script { get; set; }    
    }
}