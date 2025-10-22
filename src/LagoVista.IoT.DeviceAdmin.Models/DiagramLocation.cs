// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: b909a4cd8e6e6aab7ebebbe298c832b0c699d549aa6c4f9cd2fc1cf57b78f5d5
// IndexVersion: 0
// --- END CODE INDEX META ---
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
