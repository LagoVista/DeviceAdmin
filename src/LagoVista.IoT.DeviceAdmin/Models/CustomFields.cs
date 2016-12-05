using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class CustomFields
    {
        public enum FieldTypes
        {
            String,
            Number,
            Email,
        }


        public String Label { get; set; }
        public bool IsRequired { get; set; }        
        public FieldTypes FieldType { get; set; }
    }
}
