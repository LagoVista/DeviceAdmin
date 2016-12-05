using LagoVista.CloudStorage.Storage;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class DeviceGroupRepo : TableStorageBase<DeviceGroup>
    {

        public DeviceGroupRepo(IDeviceRepoSettings settings, ILogger logger) : base(settings.DeviceTableStorage.AccountId, settings.DeviceTableStorage.AccessKey, logger)
        {

        }

    }
}
