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
        IMediaResourceRepo _mediaRepo;

        public EquipmentManager(IEquipmentRepo repo, IDeviceAdminManager deviceAdminManager, IMediaResourceRepo mediaRepo,
            IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security) 
            : base(logger, appConfig, depmanager, security)
        {
            _mediaRepo = mediaRepo;
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

        public async Task<MediaItemResponse> GetResourceMediaAsync(string equipmentId, string id, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org.Id, typeof(MediaResource));

            var deviceType = await _repo.GetEquipmentAsync(equipmentId);
            if (deviceType == null)
            {
                throw new RecordNotFoundException(nameof(Equipment), id);
            }

            var mediaResource = deviceType.Resources.Where(dvc => dvc.Id == id).FirstOrDefault();
            if (mediaResource == null)
            {
                throw new RecordNotFoundException(nameof(MediaResource), id);
            }

            var mediaItem = await _mediaRepo.GetMediaAsync(mediaResource.FileName, org.Id);
            if (!mediaItem.Successful)
            {
                throw new RecordNotFoundException(nameof(MediaResource), id);
            }

            return new MediaItemResponse()
            {
                ContentType = mediaResource.MimeType,
                FileName = mediaResource.FileName,
                ImageBytes = mediaItem.Result
            };
        }
    }
}
