using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Infrastructure.Repositories
{
    public class RoleRepository :IRoleRepository
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        public RoleRepository(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, AppDbContext context) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public Task<IdentityResult> AddRole(AppRole Role)
        {
            return _roleManager.CreateAsync(Role);
        }

        public async Task<IdentityResult> AddRoleClaim(AppRole Role, Claim Claim)
        {
          return await _roleManager.AddClaimAsync(Role, Claim);
           
        }

        public Task<IdentityResult> AddUserInRole(AppUser User, string RoleName)
        {
           return _userManager.AddToRoleAsync(User, RoleName);
        }

        public Task<IdentityResult> DeleteRole(AppRole Role)
        {
            return  _roleManager.DeleteAsync(Role);
        }

        public Task<IdentityResult> DeleteRoleClaim(AppRole Role,Claim Claim)
        {
           return _roleManager.RemoveClaimAsync(Role, Claim);
        }

        public async Task<List<AppRole>> GetAllRoles()
        {
           return await _context.Roles.ToListAsync(); 
        }

        public async Task<AppRole> GetRoleById(string Id)
        {
           return await _roleManager.FindByIdAsync(Id);
        }

        public Task<AppRole> GetRoleByName(string Name)
        {
           return _roleManager.FindByNameAsync(Name);
        }

        public Task<IList<Claim>> GetRoleClaims(AppRole Role)
        {
           return _roleManager.GetClaimsAsync(Role);
        }

        public async Task<IList<string>> GetUserRoles(AppUser User)
        {
           
               var r= await _userManager.GetRolesAsync(User);
            return r;
        }

        public async Task<IList<AppUser>> GetUsersByRole(String RoleName)
        {

            return await _userManager.GetUsersInRoleAsync(RoleName);
        }

        public async Task<IdentityResult> RemoveUserFromRole(AppUser User, string RoleName)
        {
            return await _userManager.RemoveFromRoleAsync(User, RoleName);   
        }

        public async Task<IdentityResult> UpdateRole(AppRole Role)
        {
           return await _roleManager.UpdateAsync(Role);
        }

      
    }
}
