// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: e8851da510cabd9bf0c69dda27ebdc01c86447dac52a6ba7c5af1707c540bdaa
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.PlatformSupport;
using LagoVista.Core.Validation;
using System;
using System.Threading.Tasks;

namespace LagoVista.IoT.LabelServices.Managers
{
    public class LabelManager : ManagerBase, ILabelManager
    {
        private readonly ILabeledEntityRepo _labeledEntityRepo;
        private readonly ILabelRepo _labelRepo;

        public LabelManager(ILabelRepo labelRepo, ILabeledEntityRepo labeledEntityRepo, ILogger logger, IAppConfig appConfig, IDependencyManager dependencyManager, ISecurity security) : base(logger, appConfig, dependencyManager, security)
        {
            _labelRepo = labelRepo ?? throw new ArgumentNullException(nameof(labelRepo));
            _labeledEntityRepo = labeledEntityRepo ?? throw new ArgumentNullException(nameof(labeledEntityRepo));
        }

        public async Task<InvokeResult<LabelSet>> AddLabelAsync(Label label, EntityHeader org, EntityHeader user)
        {
            await _labelRepo.AddLabelAsync(label, org, user);
            return await GetLabelSetAsync(org, user);
        }

        public Task<ListResponse<LabeledEntity>> GetLabeledEntitiesAsync(string labelId, ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            return _labeledEntityRepo.GetLabeledEntitiesAsync(labelId, listRequest, org, user);
        }

        public async Task<InvokeResult<LabelSet>> GetLabelSetAsync(EntityHeader org, EntityHeader user)
        {
            return InvokeResult<LabelSet>.Create(await _labelRepo.GetLabelSetAsync(org, user));
        }

        public async Task<InvokeResult<LabelSet>> UpdateLabelAsync(Label label, EntityHeader org, EntityHeader user)
        {
            await UpdateLabelAsync(label, org, user);
            return await GetLabelSetAsync(org, user);
        }
    }
}
