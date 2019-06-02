using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using System.Collections.Generic;
using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.Core.Managers;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.Interfaces;
using static LagoVista.Core.Models.AuthorizeResult;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.Core;
using System.IO;
using System.Linq;
using System;
using LagoVista.Core.Exceptions;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class DeviceTypeManager : ManagerBase, IDeviceTypeManager
    {
        IDeviceTypeResourceMediaRepo _mediaRepo;
        IDeviceTypeRepo _deviceTypeRepo;

        public DeviceTypeManager(IDeviceTypeRepo deviceTypeRepo, IDeviceAdminManager deviceAdminManager, IDeviceTypeResourceMediaRepo mediaRepo,
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

        public async Task<InvokeResult<DeviceTypeResource>> AddResourceMediaAsync(String id, Stream stream, string contentType, EntityHeader org, EntityHeader user)
        {
            var deviceTypeResource = new DeviceTypeResource();
            deviceTypeResource.Id = id;
            await AuthorizeAsync(user, org, "addDeviceTypeResource", $"{{mediaItemId:'{id}'}}");

            //TODO: This code is cut-and-paste reuse in the file DeviceMediaStorage in the IoT Project, as well as the models for Device Media, probably should refactor, but it's simple enough
            deviceTypeResource.FileName = $"{deviceTypeResource.Id}.media";
            deviceTypeResource.MimeType = "application/octet-stream";

            if (contentType.ToLower().Contains("gif"))
            {
                deviceTypeResource.FileName = $"{deviceTypeResource.Id}.gif";
                deviceTypeResource.MimeType = "image/gif";
            }
            else if (contentType.ToLower().Contains("png"))
            {
                deviceTypeResource.FileName = $"{deviceTypeResource.Id}.png";
                deviceTypeResource.MimeType = "image/png";
            }
            else if (contentType.ToLower().Contains("jpg"))
            {
                deviceTypeResource.FileName = $"{deviceTypeResource.Id}.jpg";
                deviceTypeResource.MimeType = "image/jpeg";
            }
            else if (contentType.ToLower().Contains("jpeg"))
            {
                deviceTypeResource.FileName = $"{deviceTypeResource.Id}.jpeg";
                deviceTypeResource.MimeType = "image/jpeg";
            }
            else if (contentType.ToLower().Contains("pdf"))
            {
                deviceTypeResource.FileName = $"{deviceTypeResource.Id}.pdf";
                deviceTypeResource.MimeType = "application/pdf";
            }
            else if (contentType.ToLower().Contains("csv"))
            {
                deviceTypeResource.FileName = $"{deviceTypeResource.Id}.csv";
                deviceTypeResource.MimeType = "text/plain";
            }

            var bytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, (int)stream.Length);

            deviceTypeResource.ContentSize = stream.Length;

           var result = await _mediaRepo.AddMediaAsync(bytes, org.Id, deviceTypeResource.FileName, contentType);
            if(result.Successful)
            {
                return InvokeResult<DeviceTypeResource>.Create(deviceTypeResource);
            }
            else
            {
                return InvokeResult<DeviceTypeResource>.FromInvokeResult(result);
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
            await AuthorizeOrgAccessAsync(user, org.Id, typeof(DeviceTypeResource));

            var deviceType = await _deviceTypeRepo.GetDeviceTypeAsync(deviceTypeId);
            if (deviceType == null)
            {
                throw new RecordNotFoundException(nameof(DeviceType), id);
            }

            var deviceResource = deviceType.DeviceResources.Where(dvc => dvc.Id == id).FirstOrDefault();
            if (deviceResource == null)
            {
                throw new RecordNotFoundException(nameof(DeviceTypeResource), id);
            }

            var mediaItems = await _mediaRepo.GetMediaAsync(deviceResource.FileName, org.Text);
            if (!mediaItems.Successful)
            {
                throw new RecordNotFoundException(nameof(DeviceTypeResource), id);
            }

            return new MediaItemResponse()
            {
                ContentType = deviceResource.MimeType,
                FileName = deviceResource.FileName,
                ImageBytes = mediaItems.Result
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
