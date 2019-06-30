using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using System.Collections.Generic;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.Core.Managers;
using LagoVista.Core.Interfaces;
using static LagoVista.Core.Models.AuthorizeResult;
using LagoVista.IoT.Logging.Loggers;
using System.IO;
using System.Linq;
using System;
using LagoVista.Core.Exceptions;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class DeviceTypeManager : ManagerBase, IDeviceTypeManager
    {
        IDeviceTypeRepo _deviceTypeRepo;

        public DeviceTypeManager(IDeviceTypeRepo deviceTypeRepo, IDeviceAdminManager deviceAdminManager,
            IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security) :
            base(logger, appConfig, depmanager, security)
        {
            _deviceTypeRepo = deviceTypeRepo;
        }

        public async Task<InvokeResult> AddDeviceTypeAsync(DeviceType deviceType, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(deviceType, AuthorizeActions.Create, user, org);
            ValidationCheck(deviceType, Actions.Create);
            await _deviceTypeRepo.AddDeviceTypeAsync(deviceType);

            return InvokeResult.Success;
        }

        public async Task<DependentObjectCheckResult> CheckDeviceTypeInUseAsync(string id, EntityHeader org, EntityHeader user)
        {
            var deviceType = await _deviceTypeRepo.GetDeviceTypeAsync(id);
            await AuthorizeAsync(deviceType, AuthorizeActions.Read, user, org);
            return await base.CheckForDepenenciesAsync(deviceType);
        }

        public async Task<InvokeResult> DeleteDeviceTypeAsync(string id, EntityHeader org, EntityHeader user)
        {
            var deviceType = await _deviceTypeRepo.GetDeviceTypeAsync(id);
            await ConfirmNoDepenenciesAsync(deviceType);
            await AuthorizeAsync(deviceType, AuthorizeActions.Delete, user, org);
            await _deviceTypeRepo.DeleteDeviceTypeSetAsync(id);
            return InvokeResult.Success;
        }

        public async Task<DeviceType> GetDeviceTypeAsync(string id, EntityHeader org, EntityHeader user)
        {
            var deviceType = await _deviceTypeRepo.GetDeviceTypeAsync(id);
            await AuthorizeAsync(deviceType, AuthorizeActions.Read, user, org);
            return deviceType;
        }

        public async Task<IEnumerable<DeviceTypeSummary>> GetDeviceTypesForOrgsAsync(string orgId, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(DeviceType));
            return await _deviceTypeRepo.GetDeviceTypesForOrgAsync(orgId);
        }

        public Task<bool> QueryDeviceTypeKeyInUseAsync(string key, string orgId)
        {
            return _deviceTypeRepo.QueryKeyInUseAsync(key, orgId);
        }

        public async Task<InvokeResult> UpdateDeviceTypeAsync(DeviceType deviceType, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(deviceType, AuthorizeActions.Update, user, org);
            ValidationCheck(deviceType, Actions.Update);
            await _deviceTypeRepo.UpdateDeviceTypeAsync(deviceType);

            return InvokeResult.Success;
        }
    }
}
