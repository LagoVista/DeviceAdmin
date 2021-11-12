using LagoVista.Core.Interfaces;
using LagoVista.IoT.LabelServices.Managers;
using LagoVista.IoT.LabelServices.Repos;

namespace LagoVista.IoT.LabelServices
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILabeledEntityRepo, LabeledEntityRepo>();
            services.AddTransient<ILabelRepo, LabelRepo>();
            services.AddTransient<ILabelManager, LabelManager>();
        }
    }
}