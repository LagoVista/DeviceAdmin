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

        public Task<ListResponse<ILabeledEntity>> GetLabeledEntitiesAsync(string labelId, ListRequest listRequest, EntityHeader org, EntityHeader user)
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
