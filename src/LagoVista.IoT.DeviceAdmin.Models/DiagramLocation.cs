using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{

    public class DiagramLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Page { get; set; }

        public DiagramLocation Clone()
        {
            return new DiagramLocation()
            {
                X = X,
                Y = Y,
                Page = Page
            };
        }
    }
}
