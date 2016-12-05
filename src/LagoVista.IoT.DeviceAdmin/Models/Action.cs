using LagoVista.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class Action : TableStorageEntity
    {
        public String Name { get; set; }

        public String Description { get; set; }

        public Attribute Attribute {get; set;}
    }
}
