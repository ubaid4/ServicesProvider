using Microsoft.EntityFrameworkCore;
using ServicesProvider.Infrastructure.DbContext;

namespace ServicesProvider.UI.Extensions
{
    public static class RegisterContext
    {
        public static IServiceCollection RegisterAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"),op=>op.EnableRetryOnFailure());
               
            });
            return services;
        }
    }
}
