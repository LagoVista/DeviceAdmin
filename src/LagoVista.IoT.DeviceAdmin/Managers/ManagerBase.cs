using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
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



        protected Task<AuthorizeResult> AuthorizeAsync(IOwnedEntity ownedEntity, EntityHeader org, EntityHeader user, AuthorizeActions action)
        {
            return Task.FromResult(AuthorizeResult.Authorized);
        }
    }
}
