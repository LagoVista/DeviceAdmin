using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Models;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface ISharedAtributeRepo
    {
        Task AddSharedAttributeAsync(SharedAttribute sharedAction);
        Task<SharedAttribute> GetSharedAttributeAsync(string id);
        Task<IEnumerable<SharedAttributeSummary>> GetSharedAttributesForOrgAsync(string orgId);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
        Task UpdateSharedAttributeAsync(SharedAttribute sharedAttribute);
    }
}