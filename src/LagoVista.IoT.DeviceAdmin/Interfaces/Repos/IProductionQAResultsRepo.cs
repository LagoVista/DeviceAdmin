using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IProductionQAResultsRepo
    {
        Task InsertAsync(ProductionQAResult result);
        Task UpdateAsync(ProductionQAResult result);
        Task<ListResponse<ProductionQAResult>> GetForDeviceTypeAsync(string deviceTypeId, ListRequest request);
        Task<ProductionQAResult> GetForSerialNumberAsync(int serialNumber);
        Task<ProductionQAResult> GetForSerialNumberAndDeviceTypeAsync(int serialNumber, string deviceTypeId);
    }
}
