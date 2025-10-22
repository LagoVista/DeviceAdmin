// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 530759fdd08f3a6077fb937e9ea42e1bc2cd6a0994fa8fd7342da0c6b44e147b
// IndexVersion: 0
// --- END CODE INDEX META ---
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

            services.AddSingleton<IDeviceAdminManager, DeviceAdminManager>();
            services.AddSingleton<IDeviceTypeManager, DeviceTypeManager>();
            services.AddSingleton<IEquipmentManager, EquipmentManager>();
            services.AddSingleton<IPartManager, PartManager>();
            services.AddSingleton<IProductionQAResultManager, ProductionQAResultManager>();
        }
    }
}
