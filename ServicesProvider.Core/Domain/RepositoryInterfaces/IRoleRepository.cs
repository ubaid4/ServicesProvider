using Microsoft.AspNetCore.Identity;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.RepositoryInterfaces
{
    public interface IRoleRepository
    {
        Task<IdentityResult> AddRole(AppRole Role);
        Task<IdentityResult> UpdateRole(AppRole Role);
        Task<IdentityResult> DeleteRole(AppRole Role);
        Task<List<AppRole>> GetAllRoles();
        Task<IdentityResult> AddUserInRole(AppUser User,String RoleName);
        Task<IdentityResult> RemoveUserFromRole(AppUser User, String RoleName);

        Task<IList<string>> GetUserRoles(AppUser User);
        Task<IList<AppUser>> GetUsersByRole(string RoleName);
        Task<AppRole> GetRoleByName(string Name);
        Task<AppRole> GetRoleById(string Id);
        Task<IList<Claim>> GetRoleClaims(AppRole Role);

        Task<IdentityResult> AddRoleClaim(AppRole Role, Claim Claims);

        Task<IdentityResult> DeleteRoleClaim(AppRole Role,Claim Claim);
     

    }
}
