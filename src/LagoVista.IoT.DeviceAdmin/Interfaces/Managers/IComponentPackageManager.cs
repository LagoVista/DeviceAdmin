using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IComponentPackageManager
    {
        Task<InvokeResult> AddComponentPackageAsync(ComponentPackage componentPackage, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateComponentPackageAsync(ComponentPackage componentPackage, EntityHeader org, EntityHeader user);
        Task<ListResponse<ComponentPackageSummary>> GetComponentPackagesSummariesAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ComponentPackage> GetComponentPackageAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteCommponentPackageAsync(string id, EntityHeader org, EntityHeader user);
    }
}
