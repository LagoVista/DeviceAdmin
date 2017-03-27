using System;
using System.Collections.Generic;
using System.Text;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(AuthorizeResult result)
        {

        }
    }
}
