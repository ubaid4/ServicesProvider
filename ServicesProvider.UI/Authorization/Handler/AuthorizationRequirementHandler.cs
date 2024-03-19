using Microsoft.AspNetCore.Authorization;
using ServicesProvider.Core.ServicInterfaces;
using ServicesProvider.UI.Authorization.Requirements;
using System.Security.Claims;

namespace ServicesProvider.UI.Authorization.Handler
{
    public class AuthorizationRequirementHandler : AuthorizationHandler<AuthorizationRequirement>
    {
        private readonly IUserService _userService;
        public AuthorizationRequirementHandler(IUserService userService)
        {
            _userService = userService;
        }
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
        {
            ClaimsPrincipal user = context.User;
            if (user.Identity.IsAuthenticated)
            {
                Claim? UserClaim = user.FindFirst(ClaimTypes.NameIdentifier);
                if (UserClaim == null)
                {
                    context.Fail();
                    return;
                }
                bool IsAllowed = await _userService.IsUserAllowed(UserClaim.Value, requirement.Module, requirement.Action);
                
                if (IsAllowed)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }


            }
            else
            {
                context.Fail();
             
            }
            
        }
    }
}
