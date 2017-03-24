using LagoVista.Core.Attributes;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Interfaces;
using LagoVista.IoT.DeviceAdmin.Resources;
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class InputTranslatorConfiguration : PipelineModuleConfiguration
    {        
        public enum InputTranslatorTypes
        {
            Binary,
            Delimitted,
            JSON,
            XML,
            Custom
        }

        public InputTranslatorTypes InputTranslatorType { get; set; }

        public string DelimiterSequence { get; set; }

        public String Script { get; set; }        
    }
}
