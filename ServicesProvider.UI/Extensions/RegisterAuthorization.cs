using Microsoft.AspNetCore.Authorization;
using ServicesProvider.UI.Authorization.Handler;
using ServicesProvider.UI.Authorization.PolicyMaker;

namespace ServicesProvider.UI.Extensions
{
    public static class RegisterAuthorization
    {
        public static IServiceCollection RegisterAppAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));  
            });
            services.AddScoped<IAuthorizationHandler, AuthorizationRequirementHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, AppPolicyProvider>();
            return services;
        }
    }
}
