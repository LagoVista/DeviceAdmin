using System.Collections.Generic;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Models;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface ISharedActionRepo
    {
        Task AddSharedActionAsync(SharedAction sharedAction);
        Task<SharedAction> GetSharedActionAsync(string id);
        Task<IEnumerable<SharedActionSummary>> GetSharedActionsForOrgAsync(string orgId);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
        Task UpdateSharedActionAsync(SharedAction sharedAction);
    }
}