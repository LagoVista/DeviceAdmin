using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using Microsoft.Azure.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.IoT.LabelServices.Repos
{
    public class LabeledEntityRepo : DocumentDBRepoBase<LabeledEntity>, ILabeledEntityRepo
    {
        bool _shouldConsolidateCollections;

        public LabeledEntityRepo(ILabeledServiceConnectionSettings connectionSettings, IoT.Logging.Loggers.IAdminLogger logger, ICacheProvider cacheProvider = null) :
            base(connectionSettings.LabelServicesConnection.Uri, connectionSettings.LabelServicesConnection.AccessKey, connectionSettings.LabelServicesConnection.ResourceName, logger, cacheProvider)
        {
            _shouldConsolidateCollections = connectionSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public async Task<ListResponse<LabeledEntity>> GetLabeledEntitiesAsync(string labelId, ListRequest  listRequest, EntityHeader org, EntityHeader user)
        {

            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@labelId", labelId));
            var query = $"select value c from c join l in c.Labels where l.Id = @labelId";
            var result = await QueryAsync(query, parameters.ToArray());  

            // The label will e in the label set for the org.
            var taskSummaries = ListResponse<LabeledEntity>.Create(result.Where(res=>res.EntityType != "LabelSet"));
            return taskSummaries;     
        }
    }
}
