// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 1527d2759244e427ea31e45f0ce79d859d0aa429484e1941ec61b52c7bc820d4
// IndexVersion: 0
// --- END CODE INDEX META ---
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class SectionGrouping<TItem>
    {
        public SectionGrouping()
        {
            Items = new List<TItem>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<TItem> Items { get; set; }
    }
}
