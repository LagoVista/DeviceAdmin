using LagoVista.IoT.Logging.Loggers;
using Microsoft.Extensions.Configuration;

namespace LagoVista.IoT.DeviceAdmin.Repo
{
    public static class DeviceAdminModule
    {
        public static void AddDeviceAdminModule(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, IConfigurationRoot configRoot, IAdminLogger logger)
        {
            LagoVista.IoT.DeviceAdmin.Startup.ConfigureServices(services);
            Startup.ConfigureServices(services);
        }
    }
}