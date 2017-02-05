using LagoVista.Core.Interfaces;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos
{
    public interface IDeviceRepoSettings
    {
        IConnectionSettings DeviceDocDbStorage { get; set; }
        IConnectionSettings DeviceTableStorage { get; set; }

        bool ShouldConsolidateCollections { get; }
    }
}
