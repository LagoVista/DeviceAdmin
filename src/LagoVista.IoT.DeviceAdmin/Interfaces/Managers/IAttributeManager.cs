using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = LagoVista.IoT.DeviceAdmin.Models;

namespace LagoVista.IoT.DeviceAdmin.Interfaces.Managers
{
    public interface IAttributeManager
    {
        Task AddUnitSetAsync(AttributeUnitSet unitSet, EntityHeader org, EntityHeader user);
        Task<IEnumerable<AttributeUnitSetSummary>> GetUnitSetsForOrgAsync(string orgId);
        Task<AttributeUnitSet> GetUnitSetAsync(String unitSetId);
        Task UpdateUnitSetAsync(AttributeUnitSet unitSet, EntityHeader user);
        Task<bool> QueryUnitKeyInUseAsync(String key, String orgId);



        Task AddAttributeAsync(models.Attribute attribute, EntityHeader org, EntityHeader user);
        Task UpdateAttributeAsync(models.Attribute attribute, EntityHeader user);
        Task<models.Attribute> GetAttributeAsync(string attrId);
        Task<IEnumerable<models.AttributeSummary>> GetAttributesForOrgAsync(string orgId);
        Task<bool> QueryAttributeKeyInUseAsync(String key, String orgId);

    }
}
