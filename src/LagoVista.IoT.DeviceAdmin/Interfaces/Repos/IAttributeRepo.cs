using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = LagoVista.IoT.DeviceAdmin.Models;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Repos
{
    public interface IAttributeRepo
    {
        Task AddAttributeAsync(models.Attribute attribute);
        Task UpdateAttributeAsync(models.Attribute attribute);
        Task<models.Attribute> GetAttributeAsync(String attributeId);
        Task<IEnumerable<models.AttributeSummary>> GetAttributesForOrgAsync(String orgId);

        Task<bool> QueryKeyInUseAsync(String key, String orgId);
    }
}
