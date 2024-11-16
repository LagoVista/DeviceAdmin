using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IPartPackRepo
    {
        Task AddPartPackAsync(PartPack partPack);
        Task UpdatePartPackAsync(PartPack partPack);
        Task<ListResponse<PartPackSummary>> GetPartPackSummariesAsync(string id, ListRequest listRequest);
        Task<PartPack> GetPartPackAsync(string id);
        Task DeletePartPackAsync(string id);
    }
}
