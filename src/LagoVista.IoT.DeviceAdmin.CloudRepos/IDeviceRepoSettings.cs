// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 1a4aaf55d5d8f3031b631cf0c818d13d7237e203d51251c6c5b4f9c3e87ec648
// IndexVersion: 0
// --- END CODE INDEX META ---
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
