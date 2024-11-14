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
    public class ComponentPackageRepo : DocumentDBRepoBase<ComponentPackage>, IComponentPackageRepo
    {
        private bool _shouldConsolidateCollections;

        public ComponentPackageRepo(IDeviceRepoSettings settings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyMgr) :
            base(settings.DeviceDocDbStorage.Uri, settings.DeviceDocDbStorage.AccessKey, settings.DeviceDocDbStorage.ResourceName, logger, cacheProvider, dependencyMgr)
        {
            _shouldConsolidateCollections = settings.ShouldConsolidateCollections;
        }
        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddComponentPackageAsync(ComponentPackage package)
        {
            return AddComponentPackageAsync(package);
        }

        public Task DeleteCommponentPackageAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public Task<ComponentPackage> GetComponentPackageAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public Task<ListResponse<ComponentPackageSummary>> GetComponentPackagesSummariesAsync(string orgId, ListRequest listRequest)
        {
            return base.QuerySummaryAsync<ComponentPackageSummary, ComponentPackage>(qry => qry.IsPublic == true || qry.OwnerOrganization.Id == orgId, itm => itm.Name, listRequest);
        }

        public Task UpdateComponentPackageAsync(ComponentPackage package)
        {
            return UpsertDocumentAsync(package);
        }
    }
}
