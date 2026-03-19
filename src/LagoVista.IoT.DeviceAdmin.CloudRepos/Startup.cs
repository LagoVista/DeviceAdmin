
using LagoVista.IoT.DeviceAdmin.CloudRepos.Repos;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.DeviceAdmin.Repo.Repos;
using LagoVista.IoT.Logging.Loggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEquipmentRepo, EquipmentRepo>();
            services.AddSingleton<IDeviceWorkflowRepo, DeviceWorkflowRepo>();
            services.AddSingleton<IUnitSetRepo, UnitSetRepo>();
            services.AddSingleton<IStateMachineRepo, StateMachineRepo>();
            services.AddSingleton<IStateSetRepo, StateSetRepo>();
            services.AddSingleton<IPartRepo, PartRepo>();
            services.AddSingleton<IEventSetRepo, EventSetRepo>();
            services.AddSingleton<IDeviceTypeRepo, DeviceTypeRepo>();
            services.AddSingleton<IProductionQAResultsRepo, ProductionQaResultRepo>();
            services.AddSingleton<IDeviceTypeAngularAppRepo, DeviceTypeAngularAppRepo>();
        }
    }
}

namespace LagoVista.DependencyInjection
{
    public static class DeviceAdminModule
    {
        public static void AddDeviceAdminModule(this IServiceCollection services, IConfigurationRoot configRoot, IAdminLogger logger)
        {
            LagoVista.IoT.DeviceAdmin.Startup.ConfigureServices(services);
            LagoVista.IoT.DeviceAdmin.CloudRepos.Startup.ConfigureServices(services);
            services.AddMetaDataHelper<DiagramPage>();
        }
    }
}