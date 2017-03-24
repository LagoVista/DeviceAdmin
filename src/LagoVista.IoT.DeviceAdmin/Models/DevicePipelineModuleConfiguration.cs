using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class DevicePipelineModuleConfiguration<TPipelineModule> where TPipelineModule : IPipelineModuleConfiguration
    {
        public DevicePipelineModuleConfiguration()
        {
            SecondaryPipelineModuleConfigurations = new List<EntityHeader<TPipelineModule>>();
        }

        public EntityHeader<TPipelineModule> PipelineModuleConfiguration { get; set; }

        public EntityHeader<TPipelineModule> PrimaryOutputPipelineModuleConfiguration { get; set; }

        public List<EntityHeader<TPipelineModule>> SecondaryPipelineModuleConfigurations { get; set; }
    }
}