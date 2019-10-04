using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static LagoVista.Core.Models.AuthorizeResult;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class PartManager : ManagerBase, IPartManager
    {
        private readonly IPartRepo _partRepo;

        public PartManager(IPartRepo partRepo, IDeviceAdminManager deviceAdminManager,
            IAdminLogger logger, IAppConfig appConfig, IDependencyManager depmanager, ISecurity security) :
            base(logger, appConfig, depmanager, security)
        {
            _partRepo = partRepo;
        }
        public async Task<InvokeResult> AddPartAsync(Part part, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(part, AuthorizeActions.Create, user, org);
            ValidationCheck(part, Actions.Create);
            await _partRepo.AddPartAsync(part);

            return InvokeResult.Success;
        }

        public async Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user)
        {
            var part = await _partRepo.GetPartAsync(id);
            await AuthorizeAsync(part, AuthorizeActions.Read, user, org);
            return await base.CheckForDepenenciesAsync(part);
        }

        public async Task<InvokeResult> DeletePartAsync(string id, EntityHeader org, EntityHeader user)
        {
            var part = await _partRepo.GetPartAsync(id);
            await ConfirmNoDepenenciesAsync(part);
            await AuthorizeAsync(part, AuthorizeActions.Delete, user, org);
            await _partRepo.DeletePartAsync(id);
            return InvokeResult.Success;
        }

        public async Task<Part> GetPartAsync(string id, EntityHeader org, EntityHeader user)
        {
            var part = await _partRepo.GetPartAsync(id);
            await AuthorizeAsync(part, AuthorizeActions.Read, user, org);
            return part;
        }

        public async Task<Part> GetPartByPartNumberAsync(string partNumber, EntityHeader org, EntityHeader user)
        {
            var part = await _partRepo.GetPartByPartNumberAsync(org.Id, partNumber);
            await AuthorizeAsync(part, AuthorizeActions.Read, user, org);
            return part;
        }

        public async Task<Part> GetPartBySKUAsync(string sku, EntityHeader org, EntityHeader user)
        {
            var part = await _partRepo.GetPartBySKUAsync(org.Id, sku);
            await AuthorizeAsync(part, AuthorizeActions.Read, user, org);
            return part;
        }

        public async Task<ListResponse<PartSummary>> GetPartsSummaryAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org.Id, typeof(DeviceType));
            return await _partRepo.GetPartsForOrgAsync(org.Id, listRequest);

        }

        public async Task<InvokeResult> UpdatePartAsync(Part part, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(part, AuthorizeActions.Update, user, org);
            ValidationCheck(part, Actions.Update);
            await _partRepo.UpdatePartAsync(part);

            return InvokeResult.Success;
        }
    }
}
