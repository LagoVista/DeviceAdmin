﻿using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.CloudRepos.Repos;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Repo.Repos;

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
