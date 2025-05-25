using LagoVista.Core.Validation;
using LagoVista.Core;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LagoVista.Core.Interfaces;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.DeviceAdmin.CloudRepos;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using static LagoVista.IoT.DeviceAdmin.Managers.DeviceTypeManager;
using LagoVista.Core.Models;

namespace LagoVista.IoT.DeviceAdmin.Repo.Repos
{
    public class DeviceTypeAngularAppRepo : IDeviceTypeAngularAppRepo
    {
        private readonly IAdminLogger _logger;
        private readonly IConnectionSettings _connectionSettings;
        private readonly string _baseUrl;

        public DeviceTypeAngularAppRepo(IAdminLogger adminLogger, IDeviceRepoSettings connectionSettings)
        {
            _logger = adminLogger ?? throw new ArgumentNullException(nameof(adminLogger));
            _connectionSettings = connectionSettings?.DeviceTableStorage ?? throw new ArgumentNullException(nameof(connectionSettings));
            _baseUrl = $"https://{_connectionSettings.AccountId}.blob.core.windows.net";
        }

        private CloudBlobClient CreateBlobClient()
        {

            var uri = new Uri(_baseUrl);
            return new CloudBlobClient(uri, new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(_connectionSettings.AccountId, _connectionSettings.AccessKey));
        }

        private async Task<InvokeResult<CloudBlobContainer>> GetStorageContainerAsync(string containerName)
        {
            var client = CreateBlobClient();
            var container = client.GetContainerReference(containerName);
            try
            {
                var options = new BlobRequestOptions()
                {
                     MaximumExecutionTime = TimeSpan.FromSeconds(15)
                };

                var opContext = new OperationContext();
                await container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Container, options, opContext);
                return InvokeResult<CloudBlobContainer>.Create(container);
            }
            catch (ArgumentException ex)
            {
                _logger.AddException("[FirmwareBinRepo_GetStorageContainerAsync]", ex);
                return InvokeResult<CloudBlobContainer>.FromException("[FirmwareBinRepo_GetStorageContainerAsync_InitAsync]", ex);
            }
            catch (StorageException ex)
            {
                _logger.AddException("[FirmwareBinRepo_GetStorageContainerAsync", ex);
                return InvokeResult<CloudBlobContainer>.FromException("[FirmwareBinRepo_GetStorageContainerAsync]", ex);
            }
        }


        public async Task<InvokeResult<EntityHeader<string>>> AddAppFileAsync(string deviceTypeId, AngularTypeType fileType, byte[] data)
        {
            var storageContainerName = $"devicetypeapps";

            var result = await GetStorageContainerAsync(storageContainerName);
            if (!result.Successful)
            {
                return InvokeResult<EntityHeader<string>>.FromInvokeResult(result.ToInvokeResult());
            }

            var fileName = "";
            var contentType = "";

            switch(fileType)
            {
                case AngularTypeType.polyfill: fileName = $"{deviceTypeId}/polyfills.js"; contentType = "application/javascript"; break;
                case AngularTypeType.style: fileName = $"{deviceTypeId}/styles.css"; contentType = "text/css"; break;
                case AngularTypeType.main: fileName = $"{deviceTypeId}/main.js"; contentType = "application/javascript"; break;
                default:
                    return InvokeResult<EntityHeader<string>>.FromError($"Unknown Angular File Type {fileType}");
            }

            var container = result.Result;

            var blob = container.GetBlockBlobReference(fileName);
            blob.Properties.ContentType = contentType;
            blob.Properties.CacheControl = "no-cache";


            //TODO: Should really encapsulate the idea of retry of an action w/ error reporting
            var numberRetries = 5;
            var retryCount = 0;
            var completed = false;
            var stream = new MemoryStream(data);
            while (retryCount++ < numberRetries && !completed)
            {
                try
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    await blob.UploadFromStreamAsync(stream);
                }
                catch (Exception ex)
                {
                    if (retryCount == numberRetries)
                    {
                        _logger.AddException("FirmwareBinRepo_AddItemAsync", ex);
                        return InvokeResult<EntityHeader<string>>.FromException("FirmwareBinRepo_AddItemAsync", ex);
                    }
                    else
                    {
                        _logger.AddCustomEvent(LagoVista.Core.PlatformSupport.LogLevel.Warning, "FirmwareBinRepo_AddItemAsync", "", ex.Message.ToKVP("exceptionMessage"), ex.GetType().Name.ToKVP("exceptionType"), retryCount.ToString().ToKVP("retryCount"));
                    }
                    await Task.Delay(retryCount * 250);
                }
            }

            var url = $"{_baseUrl}/{storageContainerName}/{fileName}";
            var eh = new EntityHeader<string>()
            {
                Id = deviceTypeId,
                Text = fileName,
                Value = url,
            };

            return InvokeResult<EntityHeader<string>>.Create(eh);
        }
    }
}
