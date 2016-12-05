using LagoVista.CloudStorage.Storage;
using LagoVista.Core.PlatformSupport;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{ 
    public class ActionsRepo  : TableStorageBase<LagoVista.IoT.DeviceAdmin.Models.Action>
    {
        public ActionsRepo(IDeviceRepoSettings settings, ILogger logger) : base(settings.DeviceTableStorage.AccountId, settings.DeviceTableStorage.AccessKey, logger)
        {

        }
    }
}
