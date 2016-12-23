using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Managers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDeviceAdminManager, DeviceAdminManager>();
        }
    }
}
