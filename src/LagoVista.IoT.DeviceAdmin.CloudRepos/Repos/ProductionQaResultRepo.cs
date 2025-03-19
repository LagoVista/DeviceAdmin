using LagoVista.CloudStorage.Storage;
using LagoVista.Core;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.CloudRepos;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Repo.Repos
{
    public class ProductionQaResultRepo : TableStorageBase<ProductionQAResultDTO>, IProductionQAResultsRepo
    {
        public ProductionQaResultRepo(IDeviceRepoSettings settings, IAdminLogger logger) : 
            base(settings.DeviceTableStorage.AccountId, settings.DeviceTableStorage.AccessKey, logger)
        {
            
        }

        public Task InsertAsync(ProductionQAResult result)
        {
            return InsertAsync(ProductionQAResultDTO.Create(result));
        }

        public Task UpdateAsync(ProductionQAResult result)
        {
            return UpdateAsync(ProductionQAResultDTO.Create(result));
        }

        public async Task<ListResponse<ProductionQAResult>> GetForDeviceTypeAsync(string deviceTypeId, ListRequest request) 
        {
            var result = await GetPagedResultsAsync(deviceTypeId, request);
            return ListResponse<ProductionQAResult>.Create(result.Model.Select(rec => rec.ToProductionQAResult()), result);
        }

        public async Task<ProductionQAResult> GetForSerialNumberAsync(int serialNumber)
        {
            var result = await GetAsync(serialNumber.ToString());
            return result.ToProductionQAResult();
        }

        public async Task<ProductionQAResult> GetForSerialNumberAndDeviceTypeAsync(int serialNumber, string deviceTypeId)
        {
            var result = await GetAsync(serialNumber.ToString(), deviceTypeId);
            return result.ToProductionQAResult();
        }
    }

    public class ProductionQAResultDTO : TableStorageEntity
    {
        public static ProductionQAResultDTO Create(ProductionQAResult result)
        {
            return new ProductionQAResultDTO
            {
                RowKey = result.SerialNumber.ToString(),
                PartitionKey = result.DeviceType.Id,
                DeviceType = result.DeviceType.Text,
                DeviceTypeId = result.DeviceType.Id,
                Timestamp = result.TimeStamp,
                CheckedBy = result.CheckedBy.Text,
                CheckedById = result.CheckedBy.Id,
                OwnerOrganization = result.OwnerOrganization.Text,
                OwnerOrganizationId = result.OwnerOrganization.Id,
                Notes = result.Notes,
                SerialNumber = result.SerialNumber,
                DeviceUniqueId = result.DeviceUniqueId,
            };
        }

        public ProductionQAResult ToProductionQAResult()
        {
            return new ProductionQAResult()
            {
                CheckedBy = EntityHeader.Create(CheckedById, CheckedBy),
                TimeStamp = Timestamp,
                Notes = Notes,
                OwnerOrganization = EntityHeader.Create( OwnerOrganizationId, OwnerOrganization),
                DeviceType = EntityHeader.Create(DeviceTypeId, DeviceType),                  
                SerialNumber = SerialNumber,
                DeviceUniqueId = DeviceUniqueId
            };
        }

        public string OwnerOrganization { get; set; }
        public string OwnerOrganizationId { get; set; }
        public string CheckedBy { get; set; }
        public string CheckedById { get; set; }
        public int SerialNumber { get; set; }
        public string DeviceType { get; set; }
        public string DeviceTypeId { get; set; }
        public string Timestamp { get; set; }
        public string Notes { get; set; }
        public string DeviceUniqueId { get; set; }
    }
}
