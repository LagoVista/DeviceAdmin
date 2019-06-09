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
        IMediaResourceRepo _mediaRepo;
        IDeviceTypeRepo _deviceTypeRepo;

        public DeviceTypeManager(IDeviceTypeRepo deviceTypeRepo, IDeviceAdminManager deviceAdminManager, IMediaResourceRepo mediaRepo,
            IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security) :
            base(logger, appConfig, depmanager, security)
        {
            _mediaRepo = mediaRepo;
            _deviceTypeRepo = deviceTypeRepo;
        }

        public async Task<InvokeResult> AddDeviceTypeAsync(DeviceType deviceType, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(deviceType, AuthorizeActions.Create, user, org);
            ValidationCheck(deviceType, Actions.Create);
            await _deviceTypeRepo.AddDeviceTypeAsync(deviceType);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult<MediaResource>> AddResourceMediaAsync(String id, Stream stream, string contentType, EntityHeader org, EntityHeader user)
        {
            var deviceTypeResource = new MediaResource();
            deviceTypeResource.Id = id;
            await AuthorizeAsync(user, org, "addDeviceTypeResource", $"{{mediaItemId:'{id}'}}");

            deviceTypeResource.SetContentType(contentType);
         
            var bytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, (int)stream.Length);

            deviceTypeResource.ContentSize = stream.Length;

           var result = await _mediaRepo.AddMediaAsync(bytes, org.Id, deviceTypeResource.FileName, contentType);
            if(result.Successful)
            {
                return InvokeResult<MediaResource>.Create(deviceTypeResource);
            }
            else
            {
                return InvokeResult<MediaResource>.FromInvokeResult(result);
            }
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

        public async Task<MediaItemResponse> GetResourceMediaAsync(string deviceTypeId, string id, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org.Id, typeof(MediaResource));

            var deviceType = await _deviceTypeRepo.GetDeviceTypeAsync(deviceTypeId);
            if (deviceType == null)
            {
                throw new RecordNotFoundException(nameof(DeviceType), id);
            }

            var deviceResource = deviceType.Resources.Where(dvc => dvc.Id == id).FirstOrDefault();
            if (deviceResource == null)
            {
                throw new RecordNotFoundException(nameof(MediaResource), id);
            }

            var mediaItem = await _mediaRepo.GetMediaAsync(deviceResource.FileName, org.Id);
            if (!mediaItem.Successful)
            {
                throw new RecordNotFoundException(nameof(MediaResource), id);
            }

            return new MediaItemResponse()
            {
                ContentType = deviceResource.MimeType,
                FileName = deviceResource.FileName,
                ImageBytes = mediaItem.Result
            };
        }

        public async Task<MediaItemResponse> GetBomResourceMediaAsync(string deviceTypeId, string bomItemId, string id, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org.Id, typeof(MediaResource));

            var deviceType = await _deviceTypeRepo.GetDeviceTypeAsync(deviceTypeId);
            if (deviceType == null)
            {
                throw new RecordNotFoundException(nameof(DeviceType), id);
            }

            var bomItem = deviceType.BillOfMaterial.Where(dvc => dvc.Id == id).FirstOrDefault();
            if (bomItem == null)
            {
                throw new RecordNotFoundException(nameof(BOMItem), id);
            }

            var resource = bomItem.Resources.Where(bom => bom.Id == bomItemId).FirstOrDefault();
            if(resource == null)
            {
                throw new RecordNotFoundException(nameof(MediaResource), id);
            }

            var mediaItem = await _mediaRepo.GetMediaAsync(resource.FileName, org.Id);
            if (!mediaItem.Successful)
            {
                throw new RecordNotFoundException(nameof(MediaResource), id);
            }

            return new MediaItemResponse()
            {
                ContentType = resource.MimeType,
                FileName = resource.FileName,
                ImageBytes = mediaItem.Result
            };
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
