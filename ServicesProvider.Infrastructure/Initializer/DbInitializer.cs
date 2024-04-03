using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ServicesProvider.Core.Builders;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.DTOs.Roles;
using ServicesProvider.Core.Enums;
using ServicesProvider.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Infrastructure.Initializer
{
    public static class DbInitializer
    {
       
    

        public static async Task InitializeRolesAndUsers(WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();
            IServiceProvider serviceProvider = scope.ServiceProvider;

            AppDbContext context=serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<AppRole> roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            if(!context.Roles.Any())
            {
                List<AppRole> appRoles = new List<AppRole>
                {
                    new AppRole { Name = "Admin", NormalizedName = "ADMIN" , ConcurrencyStamp= Guid.NewGuid().ToString() },
                    new AppRole { Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp= Guid.NewGuid().ToString()},
                    new AppRole { Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() }
                };

                List<Claim> AdminClaims = new List<Claim> { 
                    new ClaimBuilder(AppModules.Dashboard.ToString()).CanView().CanAdd().CanEdit().CanDelete().Build(),
                    new ClaimBuilder(AppModules.Users.ToString()).CanView().CanAdd().CanEdit().CanDelete().Build(),
                    new ClaimBuilder(AppModules.Roles.ToString()).CanView().CanAdd().CanEdit().CanDelete().Build(),
                    new ClaimBuilder(AppModules.Categories.ToString()).CanView().CanAdd().CanEdit().CanDelete().Build(),
                    new ClaimBuilder(AppModules.CoreActivities.ToString()).CanView().CanAdd().CanEdit().CanDelete().Build(),
                    new ClaimBuilder(AppModules.Services.ToString()).CanView().CanAdd().CanEdit().CanDelete().Build(),
                };

                List<Claim> ManagerClaims = new List<Claim>
                {
                    new ClaimBuilder(AppModules.Dashboard.ToString()).CanView().Build(),
                    new ClaimBuilder(AppModules.Users.ToString()).CanView().Build(),
                    new ClaimBuilder(AppModules.Roles.ToString()).CanView().Build(),
                    new ClaimBuilder(AppModules.Categories.ToString()).CanView().CanAdd().CanEdit().Build(),
                    new ClaimBuilder(AppModules.CoreActivities.ToString()).CanView().CanAdd().CanEdit().Build(),
                    new ClaimBuilder(AppModules.Services.ToString()).CanView().CanAdd().CanEdit().CanDelete().Build(),
                };
                List<Claim> UserClaims = new List<Claim>
                {
                    new ClaimBuilder(AppModules.Categories.ToString()).CanView().Build(),
                    new ClaimBuilder(AppModules.CoreActivities.ToString()).CanView().Build(),
                    new ClaimBuilder(AppModules.Services.ToString()).CanView().Build(),
                };

              
                List<RoleWithClaimsInitializerDTO> roleWithClaimsInitializerDTOs = new List<RoleWithClaimsInitializerDTO>()
                {
                     new RoleWithClaimsInitializerDTO { Role = appRoles[0], ClaimList = AdminClaims },
                     new RoleWithClaimsInitializerDTO { Role = appRoles[1], ClaimList = ManagerClaims },
                     new RoleWithClaimsInitializerDTO { Role = appRoles[2], ClaimList = UserClaims }
                };
               
                foreach (var roleWithClaims in roleWithClaimsInitializerDTOs)
                {
                    await roleManager.CreateAsync(roleWithClaims.Role);
                    foreach (var claim in roleWithClaims.ClaimList)
                    {
                        await roleManager.AddClaimAsync(roleWithClaims.Role, claim);
                    }
                }


                //we also can do above with dictionary , and in this case we don't need to create RoleWithClaimsInitializerDTO
                #region Another way
                /*Dictionary<AppRole,List<Claim>> rolesWithClaims = new Dictionary<AppRole, List<Claim>>()
                {
                    {appRoles[0],AdminClaims},
                    {appRoles[1],ManagerClaims},
                    {appRoles[2],UserClaims}
                };

                foreach (var role in rolesWithClaims)
                {
                    await roleManager.CreateAsync(role.Key);
                    foreach (var Claim in role.Value)
                    {
                        await roleManager.AddClaimAsync(role.Key, Claim);
                    }
                }*/

                #endregion

                List<(AppUser, string,List<string>)> Users = new List<(AppUser, string,List<string>)>
                {
                    (new AppUser { UserName = "Alex", Email = "alex@gmail.com", EmailConfirmed=true}, "Alex!510",new List<string>{appRoles[0].Name}),
                    (new AppUser { UserName = "Ubaid", Email = "ubaid@gmail.com", EmailConfirmed = true }, "Asd@321", new List < string > { appRoles[0].Name }),
                    (new AppUser { UserName = "John", Email = "john@gmail.com", EmailConfirmed = true}, "John*412",new List<string>{appRoles[1].Name,appRoles[2].Name }),
                    (new AppUser { UserName = "Chris", Email = "chris@gmail.com", EmailConfirmed = true}, "Chris#561",new List<string>{appRoles[1].Name }),
                    (new AppUser { UserName = "Mike", Email = "mike@gmail.com", EmailConfirmed = true }, "Mike-843", new List < string > { appRoles[2].Name }),
                    (new AppUser { UserName = "Sara", Email = "sara@gmail.com", EmailConfirmed = true }, "Sara$743", new List < string > { appRoles[2].Name }),

                };
                foreach (var user in Users)
                {
                    await userManager.CreateAsync(user.Item1, user.Item2);
                    foreach (var role in user.Item3)
                    {
                        await userManager.AddToRoleAsync(user.Item1, role);
                    }
                }
            }


        }

    }
}
