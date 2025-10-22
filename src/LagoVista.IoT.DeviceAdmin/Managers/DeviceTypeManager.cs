// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 97fff2d373c263eb00a5f986b54c536716b204351c657416df96785c9fc72f89
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.Core.Managers;
using LagoVista.Core.Interfaces;
using static LagoVista.Core.Models.AuthorizeResult;
using LagoVista.IoT.Logging.Loggers;
using System;
using LagoVista.Core.Models.UIMetaData;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    

    public class DeviceTypeManager : ManagerBase, IDeviceTypeManager
    {
        private readonly IDeviceTypeRepo _deviceTypeRepo;
        private readonly IDeviceTypeAngularAppRepo _angularFileRepo;

        public DeviceTypeManager(IDeviceTypeRepo deviceTypeRepo, IDeviceTypeAngularAppRepo angularFileRepo, IDeviceAdminManager deviceAdminManager,
            IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security) :
            base(logger, appConfig, depmanager, security)
        {
            _deviceTypeRepo = deviceTypeRepo;
            _angularFileRepo = angularFileRepo;
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

        public async Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForDeviceConfigOrgAsync(string deviceConfigId, ListRequest listRequest, EntityHeader org,  EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org.Id, typeof(DeviceType));

            return await _deviceTypeRepo.GetDeviceTypesForDeviceConfigOrgAsync(deviceConfigId, org.Id, listRequest);
        }

        public async Task<DeviceType> GetDeviceTypeAsync(string id, EntityHeader org, EntityHeader user)
        {
            var deviceType = await _deviceTypeRepo.GetDeviceTypeAsync(id);
            await AuthorizeAsync(deviceType, AuthorizeActions.Read, user, org);
            return deviceType;
        }

        public async Task<ListResponse<DeviceTypeSummary>> GetDeviceTypesForOrgsAsync(ListRequest listRequest, string orgId,  EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, orgId, typeof(DeviceType));
            return await _deviceTypeRepo.GetDeviceTypesForOrgAsync(orgId, listRequest);
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

        public async Task<InvokeResult<EntityHeader<string>>> UploadAngularFileAsync(string deviceTypeId, AngularTypeType fileType, Stream stream, EntityHeader org, EntityHeader user)
        {

            var bytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, (int)stream.Length);

            return await _angularFileRepo.AddAppFileAsync(deviceTypeId, fileType, bytes);
        }
    }
}
