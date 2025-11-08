// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 498be64023ca52c4a88c5c17589f457e5fdb33d23b6a5f82c5bfb97c5eddf97a
// IndexVersion: 2
// --- END CODE INDEX META ---
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
