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
using static LagoVista.IoT.DeviceAdmin.Managers.DeviceTypeManager;
using LagoVista.Core.Models;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;

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

        private BlobServiceClient CreateBlobClient(IConnectionSettings settings)
        {
            var connectionString = $"DefaultEndpointsProtocol=https;AccountName={settings.AccountId};AccountKey={settings.AccessKey}";
            return new BlobServiceClient(connectionString);
        }

        private async Task<InvokeResult<BlobContainerClient>> GetStorageContainerAsync(string suffix, string prefix = "dtresource-", bool isPublic = false)
        {
            var client = CreateBlobClient(_connectionSettings);

            var containerName = $"{prefix}{suffix}".ToLower();

            var containerClient = client.GetBlobContainerClient(containerName);

            try
            {
                var accessType = isPublic ? PublicAccessType.BlobContainer : PublicAccessType.None;
                await containerClient.CreateIfNotExistsAsync(accessType);
                return InvokeResult<BlobContainerClient>.Create(containerClient);
            }
            catch (ArgumentException ex)
            {
                _logger.AddException("MediaServicesRepo_GetStorageContainerAsync", ex);
                return InvokeResult<BlobContainerClient>.FromException("MediaServicesRepo_GetStorageContainerAsync_InitAsync", ex);
            }
            catch (Exception ex)
            {
                _logger.AddException("MediaServicesRepo_GetStorageContainerAsync", ex);
                return InvokeResult<BlobContainerClient>.FromException("MediaServicesRepo_GetStorageContainerAsync", ex);
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

            var blob = container.GetBlobClient(fileName);
            var header = new BlobHttpHeaders { ContentType = contentType, CacheControl = "no-cache" };

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
                    var blobResult = await blob.UploadAsync(stream, new BlobUploadOptions { HttpHeaders = header });

                    var statusCode = blobResult.GetRawResponse().Status;

                    if (statusCode < 200 || statusCode > 299)
                        throw new InvalidOperationException($"Invalid response Code {statusCode}");
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
