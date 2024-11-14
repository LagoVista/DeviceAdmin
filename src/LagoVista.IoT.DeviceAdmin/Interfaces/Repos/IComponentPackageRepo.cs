using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IComponentPackageRepo
    {
        Task AddComponentPackageAsync(ComponentPackage package);
        Task UpdateComponentPackageAsync(ComponentPackage package);
        Task<ListResponse<ComponentPackageSummary>> GetComponentPackagesSummariesAsync(string id, ListRequest listRequest);
        Task<ComponentPackage> GetComponentPackageAsync(string id);
        Task DeleteCommponentPackageAsync(string id);
    }
}
