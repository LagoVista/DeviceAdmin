using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IPipelineModuleConfigurationRepo
    {
        Task AddPipelineModuleConfigurationAsync(PipelineModuleConfiguration pipelineModule);
        Task<PipelineModuleConfiguration> GetPipelineModuleConfigurationAsync(string id);
        Task<IEnumerable<PipelineModuleConfigurationSummary>> GetPipelineModuleConfigurationsForOrgsAsync(string orgId);
        Task UpdatePipelineModuleConfigurationAsync(PipelineModuleConfiguration pipelineModule);
        Task DeletePipelineModuleConfigurationAsync(string id);
        Task<bool> QueryKeyInUseAsync(String key, String orgId);
    }
}