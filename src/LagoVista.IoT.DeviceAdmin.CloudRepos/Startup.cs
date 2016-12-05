using LagoVista.IoT.DeviceAdmin.CloudRepos.Repos;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAttributeUnitSetRepo, AttributeUnitSetRepo>();
            services.AddTransient<IAttributeRepo, AttributeRepo>();
        }
    }
}
