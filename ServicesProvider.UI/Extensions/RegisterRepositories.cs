using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Infrastructure.Repositories;

namespace ServicesProvider.UI.Extensions
{
    public static class RegisterRepositories
    {
        public static void RegisterAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICoreActivityRepository, CoreActivityRepository>();
            services.AddScoped<IAppServicesRepository, ServiceRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGeneric<Category>,GenericRepository<Category>>();
            services.AddScoped<IAzureStorageRepository,AzureStorageRepository>();

        }

    }
}
