﻿using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.CloudRepos.Repos
{
    public class PartRepo : DocumentDBRepoBase<Part>, IPartRepo
    {
        private bool _shouldConsolidateCollections;

        public PartRepo(IDeviceRepoSettings settings, IAdminLogger logger, ICacheProvider cacheProvider) : 
            base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger, cacheProvider)
        {
            _shouldConsolidateCollections = settings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections { get { return _shouldConsolidateCollections; } }

        public Task AddPartAsync(Part part)
        {
            return CreateDocumentAsync(part);
        }

        public Task DeletePartAsync(string partId)
        {
            return DeletePartAsync(partId);
        }

        public Task<Part> GetPartAsync(string partId)
        {
            return GetDocumentAsync(partId);
        }

        public async Task<Part> GetPartByPartNumberAsync(string orgId, string partNumber)
        {
            var parts = await base.QueryAsync(qry => qry.OwnerOrganization.Id == orgId && qry.PartNumber == partNumber);
            return parts.FirstOrDefault();
        }

        public async Task<Part> GetPartBySKUAsync(string orgId, string sku)
        {
            var parts = await base.QueryAsync(qry => qry.OwnerOrganization.Id == orgId && qry.Sku == sku);
            return parts.FirstOrDefault();
        }

        public async Task<ListResponse<PartSummary>> GetPartsForOrgAsync(string orgId, ListRequest listRequest)
        {
            var items = await base.QueryAsync(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId);

            return ListResponse<PartSummary>.Create(from item in items
                                                 select item.CreatePartSummary());
        }

        public Task UpdatePartAsync(Part part)
        {
            return UpsertDocumentAsync(part);
        }
    }
}
