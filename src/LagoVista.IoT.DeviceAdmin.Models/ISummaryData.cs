// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 1bd5d4e850f55536b302e813fa310d076421929b3cd65c3d4803c59807473219
// IndexVersion: 0
// --- END CODE INDEX META ---
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
