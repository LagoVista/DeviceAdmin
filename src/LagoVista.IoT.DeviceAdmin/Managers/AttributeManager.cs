using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.Core.Models;
using LagoVista.Core;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class AttributeManager : IAttributeManager
    {
        IAttributeRepo _attrRepo;
        IAttributeUnitSetRepo _unitSetRepo;

        public AttributeManager(IAttributeRepo attrRepo, IAttributeUnitSetRepo unitSetRepo)
        {
            _attrRepo = attrRepo;
            _unitSetRepo = unitSetRepo;
        }

        public Task AddAttributeAsync(models.Attribute attribute, EntityHeader org, EntityHeader user)
        {
            attribute.Id = Guid.NewGuid().ToId();
            attribute.OwnerOrganization = org;
            attribute.LastUpdatedBy = user;
            attribute.CreatedBy = user;
            attribute.CreationDate = DateTime.Now.ToJSONString();
            attribute.LastUpdatedDate = attribute.CreationDate;

            return _attrRepo.AddAttributeAsync(attribute);
        }

        public Task UpdateAttributeAsync(models.Attribute attribute, EntityHeader user)
        {
            attribute.LastUpdatedBy = user;
            attribute.LastUpdatedDate = DateTime.Now.ToJSONString();

            return _attrRepo.UpdateAttributeAsync(attribute);
        }

        public Task<IEnumerable<models.AttributeSummary>> GetAttributesForOrgAsync(string orgId)
        {
            return _attrRepo.GetAttributesForOrgAsync(orgId);
        }

        public Task<bool> QueryAttributeKeyInUseAsync(string key, string orgId)
        {
            throw new NotImplementedException();
        }




        public Task<models.Attribute> GetAttributeAsync(String attributeId)
        {
            return _attrRepo.GetAttributeAsync(attributeId);
        }

        public Task AddUnitSetAsync(AttributeUnitSet unitSet, EntityHeader org, EntityHeader user)
        {
            unitSet.Id = Guid.NewGuid().ToId();
            unitSet.Organization = org;
            unitSet.LastUpdatedBy = user;
            unitSet.CreatedBy = user;
            unitSet.CreationDate = DateTime.Now.ToJSONString();


            return _unitSetRepo.AddUnitSetAsync(unitSet);
        }

        public Task<AttributeUnitSet> GetUnitSetAsync(String unitSetId)
        {
            return _unitSetRepo.GetUnitSetAsync(unitSetId);
        }

        public Task<IEnumerable<AttributeUnitSetSummary>> GetUnitSetsForOrgAsync(string orgId)
        {
            return _unitSetRepo.GetUnitSetsForOrg(orgId);
        }

        public Task UpdateUnitSetAsync(AttributeUnitSet unitSet, EntityHeader user)
        {
            unitSet.LastUpdatedBy = user;
            unitSet.LastUpdatedDate = DateTime.Now.ToJSONString();

            return _unitSetRepo.UpdateUnitSetAsync(unitSet);
        }

        public Task<bool> QueryUnitKeyInUseAsync(string key, string orgId)
        {
            throw new NotImplementedException();
        }
    }
}
