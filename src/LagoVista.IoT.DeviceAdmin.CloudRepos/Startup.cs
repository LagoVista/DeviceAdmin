using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.CloudRepos.Repos;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Repo.Repos;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEquipmentRepo, EquipmentRepo>();
            services.AddTransient<IDeviceWorkflowRepo, DeviceWorkflowRepo>();
            services.AddTransient<IUnitSetRepo, UnitSetRepo>();
            services.AddTransient<IStateMachineRepo, StateMachineRepo>();
            services.AddTransient<IStateSetRepo, StateSetRepo>();
            services.AddTransient<IPartRepo, PartRepo>();
            services.AddTransient<IEventSetRepo, EventSetRepo>();
            services.AddTransient<IDeviceTypeRepo, DeviceTypeRepo>();
            services.AddTransient<IProductionQAResultsRepo, ProductionQaResultRepo>();
        }
    }
}
