using Microsoft.AspNetCore.Identity;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.DTOs.Roles;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.ServicInterfaces
{
    public interface IRoleService
    {
        Task<BaseResponce> AddRole(RoleDTO Role);
        Task<BaseResponce> UpdateRole(RoleDTO Role);
        Task<BaseResponce> DeleteRole(string Id);
        Task<BaseResponce> GetAllRoles();
        Task<BaseResponce> AddUserInRole(string UserId, String RoleName);
        Task<BaseResponce> RemoveUserFromRole(string User, String RoleName);
        Task<BaseResponce> GetRoleById(string Id);

        Task<BaseResponce> GetRoleByUser(string UserId);
        Task<BaseResponce> GetUsersByRole(string RoleId);
        Task<BaseResponce> GetClaimsByUser(string UserId);


        Task<List<string>> GetUserRoles(String UserId);
        Task<AppRole> GetRoleByName(string Name);
        Task<IList<Claim>> GetRoleClaims(AppRole Role);

        Task<BaseResponce> AddClaimsInExistingRole(RoleClaimsDTO RoleClaims);

        Task<BaseResponce>  GetClaimsByRole (string RoleId);


        Task<BaseResponce> RemoveClaimsFromRole(string RoleId,string ClaimType);

        Task<BaseResponce> UpdateRoleClaims(RoleWithClaimsDTO RoleClaims);


        

        Task<BaseResponce> AddRoleWithClaims(RoleWithClaimsDTO RoleClaims);



    }
}
