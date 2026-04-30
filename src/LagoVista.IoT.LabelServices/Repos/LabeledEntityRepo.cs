// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 2ae1dde0d807ad47fc4fe7e89f14438b4a5f7ae7fb37d6207580050aa3f0e427
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.IoT.LabelServices.Repos
{
    public class LabeledEntityRepo : DocumentDBRepoBase<LabeledEntity>, ILabeledEntityRepo
    {
        public LabeledEntityRepo(ILabeledServiceConnectionSettings connectionSettings, IoT.Logging.Loggers.IAdminLogger logger, ICacheProvider cacheProvider = null) :
            base(connectionSettings.LabelServicesConnection.Uri, connectionSettings.LabelServicesConnection.AccessKey, connectionSettings.LabelServicesConnection.ResourceName, logger, cacheProvider)
        {
        }


        public async Task<ListResponse<LabeledEntity>> GetLabeledEntitiesAsync(string labelId, ListRequest  listRequest, EntityHeader org, EntityHeader user)
        {
            var parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("@labelId", labelId));
            var query = $"select value c from c join l in c.Labels where l.Id = @labelId";
            return await QueryAsync(query, listRequest, parameters.ToArray());  
        }

        public async Task<ListResponse<LabeledEntity>> GetLabeledEntitiesAsync(string labelId, string entityType, ListRequest listRequest, EntityHeader org, EntityHeader user)
        {

            var parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("@labelId", labelId));
            parameters.Add(new QueryParameter("@entityType", entityType));

            var query = $"select value c from c join l in c.Labels where l.Id = @labelId and c.EntityType = @entityType";
            return await QueryAsync(query, listRequest, parameters.ToArray());
        }
    }
}
