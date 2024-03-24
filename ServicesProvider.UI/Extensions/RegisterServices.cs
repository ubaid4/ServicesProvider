using ServicesProvider.Core.Services;
using ServicesProvider.Core.ServicInterfaces;

namespace ServicesProvider.UI.Extensions
{
    public static class RegisterServices
    {
        public static void RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICoreActivityService, CoreActivityService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAzureStorageService, AzureStorageService>();
        }
    }
}
