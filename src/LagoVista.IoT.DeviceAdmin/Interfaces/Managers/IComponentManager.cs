using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IComponentManager
    {
        Task<InvokeResult> AddComponentAsync(Component component, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateComponentAsync(Component component, EntityHeader org, EntityHeader user);
        Task<ListResponse<ComponentSummary>> GetComponentsSummariesAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<Component> GetComponentAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteCommponentAsync(string id, EntityHeader org, EntityHeader user);
    }
}
