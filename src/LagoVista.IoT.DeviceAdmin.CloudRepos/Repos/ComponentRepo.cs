using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceAdmin.CloudRepos;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Repo.Repos
{
    public class ComponentRepo : DocumentDBRepoBase<Component>, IComponentRepo
    {
        private bool _shouldConsolidateCollections;

        public ComponentRepo(IDeviceRepoSettings settings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyMgr) :
            base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger, cacheProvider, dependencyMgr)
        {
            _shouldConsolidateCollections = settings.ShouldConsolidateCollections;
        }

        public Task AddComponentAsync(Component component)
        {
            return CreateDocumentAsync(component);
        }

        public Task DeleteComponentAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public Task<Component> GetComponentAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public Task<ListResponse<ComponentSummary>> GetComponentSummariesAsync(string orgId, ListRequest listRequest)
        { 
            return base.QuerySummaryAsync<ComponentSummary, Component>(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, itm => itm.Name, listRequest);
        }

        public Task UpdateComponentAsync(Component component)
        {
            return UpsertDocumentAsync(component);
        }
    }
}
