// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 530759fdd08f3a6077fb937e9ea42e1bc2cd6a0994fa8fd7342da0c6b44e147b
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Managers;
using LagoVista.IoT.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Resources;

[assembly: NeutralResourcesLanguage("en")]

namespace LagoVista.IoT.DeviceAdmin
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            ErrorCodes.Register(typeof(Resources.ErrorCodes));

            services.AddScoped<IDeviceAdminManager, DeviceAdminManager>();
            services.AddScoped<IDeviceTypeManager, DeviceTypeManager>();
            services.AddScoped<IEquipmentManager, EquipmentManager>();
            services.AddScoped<IPartManager, PartManager>();
            services.AddScoped<IProductionQAResultManager, ProductionQAResultManager>();
        }
    }
}
