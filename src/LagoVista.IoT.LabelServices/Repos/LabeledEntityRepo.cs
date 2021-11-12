using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.LabelServices.Repos
{
    public class LabeledEntityRepo : DocumentDBRepoBase<ILabeledEntity>, ILabeledEntityRepo
    {
        bool _shouldConsolidateCollections;

        public LabeledEntityRepo(ILabeledServiceConnectionSettings connectionSettings, IoT.Logging.Loggers.IAdminLogger logger, ICacheProvider cacheProvider = null) :
            base(connectionSettings.LabelServicesConnection.Uri, connectionSettings.LabelServicesConnection.AccessKey, connectionSettings.LabelServicesConnection.ResourceName, logger, cacheProvider)
        {
            _shouldConsolidateCollections = connectionSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task<ListResponse<ILabeledEntity>> GetLabeledEntitiesAsync(string labelId, ListRequest  listRequest, EntityHeader org, EntityHeader user)
        {
            return QueryAsync(entity => entity.Labels.Any(lbl => lbl.Id == labelId), listRequest);
        }
    }
}
