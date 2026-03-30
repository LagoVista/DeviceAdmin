using LagoVista.Core.PlatformSupport;
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
            services.AddScoped<IEquipmentRepo, EquipmentRepo>();
            services.AddScoped<IDeviceWorkflowRepo, DeviceWorkflowRepo>();
            services.AddScoped<IUnitSetRepo, UnitSetRepo>();
            services.AddScoped<IStateMachineRepo, StateMachineRepo>();
            services.AddScoped<IStateSetRepo, StateSetRepo>();
            services.AddScoped<IPartRepo, PartRepo>();
            services.AddScoped<IEventSetRepo, EventSetRepo>();
            services.AddScoped<IDeviceTypeRepo, DeviceTypeRepo>();
            services.AddScoped<IProductionQAResultsRepo, ProductionQaResultRepo>();
            services.AddScoped<IDeviceTypeAngularAppRepo, DeviceTypeAngularAppRepo>();
            services.AddScoped<IDeviceRepoSettings, DeviceAdminConnections>();
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


