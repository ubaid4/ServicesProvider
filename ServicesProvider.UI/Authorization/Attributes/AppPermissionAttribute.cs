using Microsoft.AspNetCore.Authorization;
using ServicesProvider.Core.Enums;
using System.Diagnostics;

namespace ServicesProvider.UI.Authorization.Attributes
{
    public class AppPermissionAttribute : AuthorizeAttribute
    {
        public AppPermissionAttribute(AppModules Module, ModuleAction Action) : base(Module + "-" + Action)
        {
         
        }

    }
}
