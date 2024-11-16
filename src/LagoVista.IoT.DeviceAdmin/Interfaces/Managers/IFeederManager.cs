using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IFeederManager
    {
        Task<InvokeResult> AddFeederAsync(Feeder feeder, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateFeederAsync(Feeder feeder, EntityHeader org, EntityHeader user);
        Task<ListResponse<FeederSummary>> GetFeedersSummariesAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<Feeder> GetFeederAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteCommponentAsync(string id, EntityHeader org, EntityHeader user);

    }
}
