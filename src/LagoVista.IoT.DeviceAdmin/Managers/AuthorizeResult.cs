using LagoVista.Core.Validation;

namespace LagoVista.IoT.DeviceAdmin.Managers
{
    public class AuthorizeResult
    {
        public bool IsAuthorized { get; private set; }
        public static AuthorizeResult Authorized { get { return new AuthorizeResult() { IsAuthorized = true }; } }

        public InvokeResult ToActionResult()
        {
            return new InvokeResult()
            {
                
            };
        }
    }
}