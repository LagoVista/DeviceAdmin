// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 09f1f4a44304c3bc4108f14476ffe9e6ea9de6cee0bb3310c7cf65cfa150b114
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.CloudStorage.Interfaces;
using LagoVista.Core;
using LagoVista.Core.Exceptions;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.LabelServices.Repos
{
    public class LabelRepo : DocumentDBRepoBase<LabelSet>, ILabelRepo
    {
        private readonly ICacheProvider _cacheProvider;

        public LabelRepo(IDocumentCloudCachedServices services) : base(services)
        {
            _cacheProvider = services.CacheProvider ?? throw new ArgumentNullException(nameof(services.CacheProvider)); 
        }

        private string CacheKey(EntityHeader org)
        {
            return $"{nameof(LabelSet)}_fororg_{org.Id}_v2";
        }

        public async Task<LabelSet> AddLabelAsync(Label label, EntityHeader org, EntityHeader user)
        {
            var labelSet = await GetLabelSetAsync(org, user);

            if(!labelSet.Labels.Any(lbs=>lbs.Text.ToLower() == label.Text.ToLower()))
            {
                await _cacheProvider.RemoveAsync(CacheKey(org));
                labelSet.Labels.Add(label);
                await UpsertDocumentAsync(labelSet);
            }

            await _cacheProvider.AddAsync(CacheKey(org), JsonConvert.SerializeObject(labelSet));

            return labelSet;
        }
        
        private async Task EnsureIdsAsync(LabelSet labelSet)
        {
            var requiresUpdate = false;

            foreach (var label in labelSet.Labels)
            {
                if (String.IsNullOrEmpty(label.Id))
                {
                    label.Id = NormalizedId32.Factory();
                    requiresUpdate = true;
                }
            }

            if (requiresUpdate)
            {
                await UpsertDocumentAsync(labelSet);
            }
        }

        public async Task<LabelSet> GetLabelSetAsync(EntityHeader org, EntityHeader user)
        {
            var json = await _cacheProvider.GetAsync(CacheKey(org));
           if(!String.IsNullOrEmpty(json))
           {
                var cachedLabelSet = JsonConvert.DeserializeObject<LabelSet>(json);
                await EnsureIdsAsync(cachedLabelSet);
                return cachedLabelSet;
            }

            var labelSet = (await QueryAsync(lbs => lbs.OwnerOrganization.Id == org.Id)).FirstOrDefault();
            if (labelSet == null)
            {
                labelSet = new LabelSet()
                {
                    Id = Guid.NewGuid().ToId(),
                    CreatedBy = user,
                    LastUpdatedBy = user,
                    CreationDate = UtcTimestamp.Now,  
                    LastUpdatedDate = UtcTimestamp.Now,
                    IsPublic = false,
                    OwnerOrganization = org,
                    Labels = new List<Label>()
                };

                await CreateDocumentAsync(labelSet);
            }
            else
            {

                if (labelSet.Labels == null)
                {
                    labelSet.Labels = new List<Label>();
                }

                await EnsureIdsAsync(labelSet);
            }

            await _cacheProvider.AddAsync(CacheKey(org), JsonConvert.SerializeObject(labelSet));

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

            await _cacheProvider.RemoveAsync(CacheKey(org));
            await UpsertDocumentAsync(labelSet);

            await _cacheProvider.AddAsync(CacheKey(org), JsonConvert.SerializeObject(labelSet));
            return labelSet;
        }
    }
}
