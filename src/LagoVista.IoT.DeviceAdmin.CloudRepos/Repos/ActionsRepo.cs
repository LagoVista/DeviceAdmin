using LagoVista.CloudStorage.DocumentDB;
using LagoVista.CloudStorage.Storage;
using LagoVista.Core.PlatformSupport;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{ 
    public class ActionsRepo  : DocumentDBRepoBase<LagoVista.IoT.DeviceAdmin.Models.Action>
    {
        public ActionsRepo(IDeviceRepoSettings settings, ILogger logger) : base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger)
        {

        }
    }
}
