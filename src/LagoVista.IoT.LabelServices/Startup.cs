// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: f08f4102c2ae66a30832ad140a0a439d5effed4bd1132658de151dd1bd3d4894
// IndexVersion: 0
// --- END CODE INDEX META ---
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