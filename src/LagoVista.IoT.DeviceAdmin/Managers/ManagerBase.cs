using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.IoT.DeviceAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class ManagerBase
    {
        public enum AuthorizeActions
        {
            Create,
            Read,
            Update,
            Delete,
            GetForOrgs,
        }

        protected Task<AuthorizeResult> AuthorizeAsync(IOwnedEntity ownedEntity, AuthorizeActions action, EntityHeader user, EntityHeader org = null)
        {
            return Task.FromResult(AuthorizeResult.Authorized);
        }

        protected Task<DependentObjectCheckResult> CheckDepenenciesAsync(Object instance)
        {
            return Task.FromResult(new DependentObjectCheckResult()
            {
                
            });
        }

        protected Task<AuthorizeResult> AuthorizeOrgAccess(string userId, string orgId, Type entityType = null)
        {
            return Task.FromResult(AuthorizeResult.Authorized);
        }

        protected Task<AuthorizeResult> AuthorizeOrgAccess(EntityHeader user, string orgId, Type entityType = null)
        {
            return Task.FromResult(AuthorizeResult.Authorized);
        }

        protected Task<AuthorizeResult> AuthorizeOrgAccess(EntityHeader user, EntityHeader org, Type entityType = null)
        {
            return Task.FromResult(AuthorizeResult.Authorized);
        }
    }
}
