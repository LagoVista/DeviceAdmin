using LagoVista.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Models
{
    public interface ISummaryData : IIDEntity, IKeyedEntity, INamedEntity
    {    
        bool IsPublic { get; }
        string Description { get; }
    }
}
