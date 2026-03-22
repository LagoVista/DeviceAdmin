using LagoVista.Core.Interfaces;
using LagoVista.IoT.LabelServices;
using Microsoft.Extensions.Configuration;

namespace LagoVista.IoT.DeviceAdmin.Repo
{
    public class LabeledServiceConnectionSettings : ILabeledServiceConnectionSettings
    {
        public IConnectionSettings LabelServicesConnection { get;  }
        public LabeledServiceConnectionSettings(IConfiguration configuration)
        {
            LabelServicesConnection = configuration.CreateDefaultDBStorageSettings();
        }
    }
}
