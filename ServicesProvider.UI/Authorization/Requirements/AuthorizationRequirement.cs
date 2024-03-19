using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace ServicesProvider.UI.Authorization.Requirements
{
    public class AuthorizationRequirement : IAuthorizationRequirement
    {
        public string Module { get; set; }
        public string Action { get; set; }
        public AuthorizationRequirement(string _module, string _action)
        {

            Module = _module;
            Action = _action;
        }
    }
}
