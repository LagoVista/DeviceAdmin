using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public class DependentObjectCheckResult
    {
        public bool IsInUse
        {
            get; private set;
        } = false;

        
        public IEnumerable<SummaryData> DependentObjects { get; }
    }
}
