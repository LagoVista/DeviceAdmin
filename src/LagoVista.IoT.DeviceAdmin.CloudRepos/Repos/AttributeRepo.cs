using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.PlatformSupport;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models = LagoVista.IoT.DeviceAdmin.Models;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class AttributeRepo  : DocumentDBRepoBase<models.Attribute>, IAttributeRepo
    {
        public AttributeRepo(IDeviceRepoSettings settings, ILogger logger) : base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger)
        {

        }

        public Task AddAttributeAsync(models.Attribute attribute)
        {
            return CreateDocumentAsync(attribute);
        }

        public Task UpdateAttributeAsync(models.Attribute attribute)
        {
            return base.UpsertDocumentAsync(attribute);
        }

        public Task<models.Attribute> GetAttributeAsync(String attributeId)
        {
            return GetDocumentAsync(attributeId);
        }

        public async Task<bool> QueryKeyInUseAsync(String key, String orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public async Task<IEnumerable<models.AttributeSummary>> GetAttributesForOrgAsync(string orgId)
        {
            var items = await base.QueryAsync(attr => attr.OwnerOrganization.Id == orgId || attr.IsPublic == true);

            return from item in items
                   select item.CreateSummary();
        }
    }
}
