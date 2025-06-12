using LagoVista.Core;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class ProductionQAResultManager : ManagerBase, IProductionQAResultManager
    {
        IProductionQAResultsRepo _repo;
        IDeviceTypeRepo _deviceTypeRepo;
        ISerialNumberManager _serialNumberManager;
        IAdminLogger _adminLogger;

        public ProductionQAResultManager(IProductionQAResultsRepo repo, ISerialNumberManager serialNumberManager, IDeviceTypeRepo deviceTypeRepo, IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security) :
            base(logger, appConfig, depmanager, security)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _deviceTypeRepo = deviceTypeRepo ?? throw new ArgumentNullException(nameof(deviceTypeRepo));
            _serialNumberManager = serialNumberManager ?? throw new ArgumentNullException(nameof(serialNumberManager));
            _adminLogger = logger;
        }


        public async Task<InvokeResult<ProductionQAResult>> CompleteQAAsync(string deviceTypeId, EntityHeader org, EntityHeader user)
        {
            var deviceType = await _deviceTypeRepo.GetDeviceTypeAsync(deviceTypeId);    
            if(deviceType.OwnerOrganization.Id != org.Id)
            {
                throw new UnauthorizedAccessException($"Org Mis-Match Device Type Owner {deviceType.OwnerOrganization.Text} Current: {org.Text}");
            }


            var serialNumber = await _serialNumberManager.GenerateSerialNumber("SYSTEMWIDE", "productionqaresult", seed: 10035);
            _adminLogger.Trace($"[ProductionQAResultManager__CompleteQAAsync] - Device Type Id: {deviceTypeId}, Serial Number {serialNumber}");

            var result = new ProductionQAResult()
            {
                OwnerOrganization = org,
                CheckedBy = user,
                SerialNumber = serialNumber,
                TimeStamp = DateTime.UtcNow.ToJSONString(),
                DeviceType = deviceType.ToEntityHeader(),
                Notes = String.Empty
            };

            await _repo.InsertAsync(result);

            return InvokeResult<ProductionQAResult>.Create(result);
            
        }

        public async Task<ListResponse<ProductionQAResult>> GetForDeviceTypeAsync(string deviceTypeId, ListRequest request, EntityHeader org, EntityHeader user)
        {
            var deviceType = await _deviceTypeRepo.GetDeviceTypeAsync(deviceTypeId);
            if (deviceType.OwnerOrganization.Id != org.Id)
            {
                throw new UnauthorizedAccessException($"Org Mis-Match Device Type Owner {deviceType.OwnerOrganization.Text} Current: {org.Text}");
            }

            return await _repo.GetForDeviceTypeAsync(deviceTypeId, request);
        }

        public async Task<InvokeResult<ProductionQAResult>> GetForSerialNumberAsync(int serialNumber)
        {
            var result = await _repo.GetForSerialNumberAsync(serialNumber);
            return InvokeResult<ProductionQAResult>.Create(result);
        }

        public async Task<InvokeResult<ProductionQAResult>> GetForSerialNumberAndDeviceTypeAsync(int serialNumber, string deviceTypeId)
        {
            var result = await _repo.GetForSerialNumberAndDeviceTypeAsync(serialNumber, deviceTypeId);
            return InvokeResult<ProductionQAResult>.Create(result);
        }

        public async Task<InvokeResult<ProductionQAResult>> SetForDeviceAsync(int serialNumber, string deviceTypeId, string deviceUniqueId, EntityHeader org, EntityHeader user)
        {
            var result = await _repo.GetForSerialNumberAndDeviceTypeAsync(serialNumber, deviceTypeId);
            result.DeviceUniqueId = deviceUniqueId;
            await _repo.UpdateAsync(result);

            return InvokeResult<ProductionQAResult>.Create(result);
        }
    }
}
