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
                LocationId = result.Location?.Id,
                Location = result.Location?.Text,
                RoomId = result.Room?.Id,
                Room = result.Room?.Text,
                ShelfUnitId = result.ShelfUnit?.Id,
                ShelfUnit = result.ShelfUnit?.Text,
                ShelfId = result.Shelf?.Id,
                Shelf= result.Shelf?.Text,
                ColumnId = result.Column?.Id,
                Column = result.Column?.Text,
                Customer = result.Customer?.Text,
                CustomerId = result.Customer?.Id
            };
        }

        public ProductionQAResult ToProductionQAResult()
        {
            var result = new ProductionQAResult()
            {
                CheckedBy = EntityHeader.Create(CheckedById, CheckedBy),
                TimeStamp = Timestamp,
                Notes = Notes,
                OwnerOrganization = EntityHeader.Create( OwnerOrganizationId, OwnerOrganization),
                DeviceType = EntityHeader.Create(DeviceTypeId, DeviceType),                  
                SerialNumber = SerialNumber,
                DeviceUniqueId = DeviceUniqueId
            };

            if (!string.IsNullOrEmpty(Location) && !String.IsNullOrEmpty(LocationId))
                result.Location = EntityHeader.Create(LocationId, Location);

            if (!string.IsNullOrEmpty(Room) && !String.IsNullOrEmpty(RoomId))
                result.Room = EntityHeader.Create(RoomId, Room);

            if (!string.IsNullOrEmpty(ShelfUnit) && !String.IsNullOrEmpty(ShelfUnitId))
                result.ShelfUnit = EntityHeader.Create(ShelfUnitId, ShelfUnit);

            if (!string.IsNullOrEmpty(Shelf) && !String.IsNullOrEmpty(ShelfId))
                result.Shelf = EntityHeader.Create(ShelfId, Shelf);

            if (!string.IsNullOrEmpty(Column) && !String.IsNullOrEmpty(ColumnId))
                result.Column = EntityHeader.Create(ColumnId, Column);

            if (!string.IsNullOrEmpty(Customer) && !String.IsNullOrEmpty(CustomerId))
                result.Customer = EntityHeader.Create(CustomerId, Customer);

            return result;
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


        public string Location { get; set; }
        public string Room { get; set; }
        public string ShelfUnit { get; set; }
        public string Shelf { get; set; }
        public string Column { get; set; }
        public string Customer { get; set; }

        public string LocationId { get; set; }
        public string RoomId { get; set; }
        public string ShelfUnitId { get; set; }
        public string ShelfId { get; set; }
        public string ColumnId { get; set; }
        public string CustomerId { get; set; }
    }
}
