using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Infrastructure.DbContext;

namespace ServicesProvider.UI.Extensions
{
    public static class RegisterIdentity
    {
    
        public static IServiceCollection RegisterAppIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                //set password complexity
                /*options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;*/

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;

               

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().
                AddUserStore<UserStore<AppUser, AppRole, AppDbContext, Guid>>().
                AddRoleStore<RoleStore<AppRole, AppDbContext, Guid>>(); ;
           return services;
        }
    }
}
