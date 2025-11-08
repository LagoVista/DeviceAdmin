// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 0d9c85e5c9fd6bcdaedde592e5d1dcb7ddf143e25c8d501265891b1d23620da2
// IndexVersion: 2
// --- END CODE INDEX META ---
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class DeviceComments
    {

        public String Id { get; set; }
        public String DeviceId { get; set; }

        public String DateStamp { get; set; }

        public String Message { get; set; }
    }
}
