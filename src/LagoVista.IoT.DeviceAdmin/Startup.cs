using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Managers;
using LagoVista.IoT.Logging;
using System.Resources;

[assembly: NeutralResourcesLanguage("en")]

namespace LagoVista.IoT.DeviceAdmin
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            ErrorCodes.Register(typeof(Resources.ErrorCodes));

            services.AddTransient<IDeviceAdminManager, DeviceAdminManager>();
            services.AddTransient<IDeviceTypeManager, DeviceTypeManager>();
            services.AddTransient<IEquipmentManager, EquipmentManager>();
            services.AddTransient<IPartManager, PartManager>();
            services.AddTransient<IComponentManager, ComponentManager>();
            services.AddTransient<IComponentPackageManager, ComponentPackageManager>();
            services.AddTransient<IFeederManager, FeederManager>();
            services.AddTransient<IPartPackManager, PartPackManager>();
        }
    }
}
