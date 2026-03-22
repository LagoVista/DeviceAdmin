using LagoVista.Core.Interfaces;
using LagoVista.IoT.DeviceAdmin.Repo;
using LagoVista.IoT.LabelServices.Managers;
using LagoVista.IoT.LabelServices.Repos;
using LagoVista.IoT.Logging.Loggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LagoVista.IoT.LabelServices
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILabeledEntityRepo, LabeledEntityRepo>();
            services.AddTransient<ILabelRepo, LabelRepo>();
            services.AddTransient<ILabelManager, LabelManager>();
            services.AddTransient<ILabeledServiceConnectionSettings, LabeledServiceConnectionSettings>();
        }
    }
}

namespace LagoVista.DependencyInjection
{
    public static class LabelModule
    {
        public static void AddLabelModule(this IServiceCollection services, IConfigurationRoot configRoot, IAdminLogger logger)
        {
            LagoVista.IoT.LabelServices.Startup.ConfigureServices(services);
        }
    }
}