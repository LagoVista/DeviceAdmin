
using System;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class OutputTranslatorConfiguration : PipelineModuleConfiguration
    {
        public enum OutputTranslatorTypes
        {
            Binary,
            Delimitted,
            JSON,
            XML,
            Custom
        }

        public OutputTranslatorTypes OutputTranslatorType { get; set; }

        public string DelimiterSequence { get; set; }

        public String Script { get; set; }
    }
}
