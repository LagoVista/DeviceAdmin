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
