// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 014cd43f1d3b26acdcc6771f7b377b7a36a1d71a109c12f9b2f1fca73d51136d
// IndexVersion: 0
// --- END CODE INDEX META ---
using System.Threading.Tasks;
using LagoVista.Core.Exceptions;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Linq;
using static LagoVista.Core.Models.AuthorizeResult;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class EquipmentManager : ManagerBase, IEquipmentManager
    {
        IEquipmentRepo _repo;

        public EquipmentManager(IEquipmentRepo repo, IDeviceAdminManager deviceAdminManager,
            IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security) 
            : base(logger, appConfig, depmanager, security)
        {
            _repo = repo;
        }

        public async Task<InvokeResult> AddEquipmentAsync(Equipment equipment, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(equipment, AuthorizeActions.Create, user, org);
            ValidationCheck(equipment, Actions.Create);
            await _repo.AddEquipmentAsync(equipment);

            return InvokeResult.Success;
        }

        public async Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user)
        {
            var equipment = await _repo.GetEquipmentAsync(id);
            await AuthorizeAsync(equipment, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(equipment);
        }

        public async Task<InvokeResult> DeleteEquipmentAsync(string id, EntityHeader org, EntityHeader user)
        {
            var equipment = await _repo.GetEquipmentAsync(id);
            await ConfirmNoDepenenciesAsync(equipment);
            await AuthorizeAsync(equipment, AuthorizeActions.Delete, user, org);
            await _repo.DeleteEquipmentAsync(id);
            return InvokeResult.Success;
        }

        public async Task<Equipment> GetEquipmentAsync(string id, EntityHeader org, EntityHeader user)
        {
            var equipment = await _repo.GetEquipmentAsync(id);
            await AuthorizeAsync(equipment, AuthorizeActions.Read, user, org);
            return equipment;
        }

        public async Task<ListResponse<EquipmentSummary>> GetEquipmentSummaryAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org.Id, typeof(EquipmentSummary));
            return await _repo.GetToolSummariesForOrgAsync(org.Id, listRequest);
        }

        public Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            return _repo.QueryKeyInUseAsync(key, orgId);
        }

        public async Task<InvokeResult> UpdateEquipmentAsync(Equipment equipment, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(equipment, AuthorizeActions.Update, user, org);
            ValidationCheck(equipment, Actions.Update);
            await _repo.UpdateEquipmentAsync(equipment);

            return InvokeResult.Success;
        }
    }
}
