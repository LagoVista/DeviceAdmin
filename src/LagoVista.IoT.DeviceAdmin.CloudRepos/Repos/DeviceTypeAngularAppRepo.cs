using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using System.Threading.Tasks;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.DeviceAdmin.CloudRepos;
using LagoVista.Core.Models;
using LagoVista.CloudStorage.Storage;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;

namespace LagoVista.IoT.DeviceAdmin.Repo.Repos
{
    public class DeviceTypeAngularAppRepo : CloudFileStorage, IDeviceTypeAngularAppRepo
    {
        public DeviceTypeAngularAppRepo(IAdminLogger adminLogger, IDeviceRepoSettings connectionSettings) : 
            base(connectionSettings.DeviceTableStorage.AccountId, connectionSettings.DeviceTableStorage.AccessKey, adminLogger)
        {
        }

      
        public async Task<InvokeResult<EntityHeader<string>>> AddAppFileAsync(string deviceTypeId, AngularTypeType fileType, byte[] data)
        {
            var storageContainerName = $"devicetypeapps";

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

            var result = await AddFileAsync(storageContainerName, fileName, data, contentType, "no-cache");

            var eh = new EntityHeader<string>()
            {
                Id = deviceTypeId,
                Text = fileName,
                Value = result.Result.ToString(),
            };

            return InvokeResult<EntityHeader<string>>.Create(eh);
        }
    }
}
