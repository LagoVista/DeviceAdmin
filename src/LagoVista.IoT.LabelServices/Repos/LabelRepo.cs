using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LagoVista.Core;
using LagoVista.Core.Exceptions;

namespace LagoVista.IoT.LabelServices.Repos
{
    public class LabelRepo : DocumentDBRepoBase<LabelSet>, ILabelRepo
    {
        bool _shouldConsolidateCollections;

        public LabelRepo(ILabeledServiceConnectionSettings connectionSettings, IoT.Logging.Loggers.IAdminLogger logger, ICacheProvider cacheProvider = null) :
            base(connectionSettings.LabelServicesConnection.Uri, connectionSettings.LabelServicesConnection.AccessKey, connectionSettings.LabelServicesConnection.ResourceName, logger, cacheProvider)
        {
            _shouldConsolidateCollections = connectionSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public async Task<LabelSet> AddLabelAsync(Label label, EntityHeader org, EntityHeader user)
        {
            var labelSet = await GetLabelSetAsync(org, user);

            if(!labelSet.Labels.Any(lbs=>lbs.Text.ToLower() == label.Text.ToLower()))
            {
                labelSet.Labels.Add(label);
                await UpsertDocumentAsync(labelSet);
            }

            return labelSet;
        }

        public async Task<LabelSet> GetLabelSetAsync(EntityHeader org, EntityHeader user)
        {
            var labelSet = (await QueryAsync(lbs => lbs.OwnerOrganization.Id == org.Id)).FirstOrDefault();
            if (labelSet == null)
            {
                labelSet = new LabelSet()
                {
                    Id = Guid.NewGuid().ToId(),
                    CreatedBy = user,
                    LastUpdatedBy = user,
                    CreationDate = DateTime.UtcNow.ToJSONString(),  
                    LastUpdatedDate = DateTime.UtcNow.ToJSONString(),
                    IsPublic = false,
                    OwnerOrganization = org
                };

                await CreateDocumentAsync(labelSet);
            }

            if(labelSet.Labels == null)
            {
                labelSet.Labels = new List<Label>();
            }

            return labelSet;
        }

        public async Task<LabelSet> UpdateLabelAsync(Label updatedLabel, EntityHeader org, EntityHeader user)
        {
            var labelSet = await GetLabelSetAsync(org, user);

            var existingLabel = labelSet.Labels.SingleOrDefault(lbl => lbl.Id == updatedLabel.Id);
            if(existingLabel == null)
            {
                throw new RecordNotFoundException(nameof(Label), updatedLabel.Id);
            }

            existingLabel.ForegroundColor = updatedLabel.ForegroundColor;
            existingLabel.BackgroundColor = updatedLabel.BackgroundColor;
            existingLabel.Text = updatedLabel.Text;
            existingLabel.Description = updatedLabel.Description;

            await UpsertDocumentAsync(labelSet);
            return labelSet;
        }
    }
}
