using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class DeviceRepo : DocumentDBRepoBase<Device>
    {
        public DeviceRepo(IDeviceRepoSettings repoSettings, ILogger logger) : base(repoSettings.DeviceDocDbStorage.Uri, repoSettings.DeviceDocDbStorage.AccessKey, repoSettings.DeviceDocDbStorage.ResourceName, logger)
        {

        }

        public async Task AddDeviceAsync(Device item) 
        {
            await CreateDocumentAsync(item);
        }

        public async Task UpdateDeviceAsync(Device item)
        {
            await UpsertDocumentAsync(item);
        }

        public  Task DeleteDeviceAsync(Device item)
        {
            return DeleteDeviceByIdAsync(item.Id);
        }

        public async Task DeleteDeviceByIdAsync(String id)
        {
            await DeleteDocumentAsync(id);
        }

        public  Task<Device> GetDeviceByIdAsync(String id) 
        {
            return GetDocumentAsync(id);
        }

        public async Task<Device> GetDeviceByDeviceIdAsync(String deviceId) 
        {
            return (await QueryAsync(dvc => dvc.DeviceId == deviceId)).FirstOrDefault();
        }

        public Task<IEnumerable<Device>> GetDevicesByAccountAsync(String accountId)
        {
            return QueryAsync(dvc => dvc.Account.Id == accountId);
        } 
    }
}