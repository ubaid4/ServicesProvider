using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.DTOs.Roles;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.DTOs.Users;
using ServicesProvider.Core.ServicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
  
        public RoleService(IRoleRepository roleRepository,IMapper mapper,IUserRepository userRepository) 
        { 
            _roleRepository = roleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<BaseResponce> AddClaimsInExistingRole(RoleClaimsDTO RoleClaims)
        {
           
           AppRole Role =await _roleRepository.GetRoleById(RoleClaims.RoleId);

            if (Role == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Role not found" };
            }

            foreach (ClaimDTO claim in RoleClaims.Claims)
            {
                string ClaimValue=JsonSerializer.Serialize(claim.Value);
                await _roleRepository.AddRoleClaim(Role, new Claim(claim.Type, ClaimValue));
            }

         return new BaseResponce { IsSuccess = true, Message = "Claims added in role successfully" };
            
        }

        public async Task<BaseResponce> AddRole(RoleDTO RoleData)
        {
            RoleData.Id= Guid.NewGuid().ToString();
            AppRole role=_mapper.Map<AppRole>(RoleData);
            IdentityResult result=await _roleRepository.AddRole(role);
            if(!result.Succeeded)
            {
                return new BaseResponce { IsSuccess = false,Message = "failed to add role",Errors=result.Errors.Select(x=>x.Description).ToList() };
            }
            return new BaseResponce { IsSuccess = true, Message = "Role added successfully" };
        }

        public async Task<BaseResponce> AddRoleWithClaims(RoleWithClaimsDTO RoleClaims)
        {
           RoleClaims.Role.Id = Guid.NewGuid().ToString();
           AppRole Role = _mapper.Map<AppRole>(RoleClaims.Role);
           IdentityResult result =await _roleRepository.AddRole(Role);
            if (!result.Succeeded)
            {
                return new BaseResponce { IsSuccess = false, Message = "failed to add role", Errors = result.Errors.Select(x => x.Description).ToList() };
            }
            foreach (ClaimDTO claim in RoleClaims.Claims)
            {
                string ClaimValue = JsonSerializer.Serialize(claim.Value);
                await _roleRepository.AddRoleClaim(Role, new Claim(claim.Type, ClaimValue));
            }
           

            return new BaseResponce { IsSuccess = true, Message = "Role added with claims successfully" };
        }

        public async Task<BaseResponce> AddUserInRole(string UserId, string RoleName)
        {
           AppUser User =await _userRepository.GetUserById(UserId);
            if(User==null)
            {
                return new BaseResponce { IsSuccess = false, Message = "User not found" };
            }
            IdentityResult result = await _roleRepository.AddUserInRole(User, RoleName);
            if (!result.Succeeded)
            {
                return new BaseResponce { IsSuccess = false, Message = "failed to add user in role", Errors = result.Errors.Select(x => x.Description).ToList() };
            }
            return new BaseResponce { IsSuccess = true, Message = "User added in role successfully" };
        }

        public async Task<BaseResponce> DeleteRole(string Id)
        {
            AppRole Role= await _roleRepository.GetRoleById(Id);
            if(Role==null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Role not found" };
            }
            IdentityResult result = await _roleRepository.DeleteRole(Role);
            if (!result.Succeeded)
            {
                return new BaseResponce { IsSuccess = false, Message = "failed to delete role", Errors = result.Errors.Select(x => x.Description).ToList() };
            }
            ClaimsPrincipal principal = new ClaimsPrincipal();
            return new BaseResponce { IsSuccess = true, Message = "Role deleted successfully" };
        }

        public async Task<BaseResponce> GetAllRoles()
        {
            List<AppRole> Roles= await _roleRepository.GetAllRoles();
            if(Roles==null)
            {
                return new BaseResponce { IsSuccess = true, Message = "No role found" };
            }
            return new GenericResponce { IsSuccess = true, Message = "Roles fetched successfully", Data = Roles.Select(x => _mapper.Map<RoleDTO>(x)).ToList() };
        }

        public async Task<BaseResponce> GetClaimsByRole(string RoleId)
        {
            AppRole role  =await _roleRepository.GetRoleById(RoleId);
            if (role == null)
            {
                return new BaseResponce { IsSuccess = true, Message = "Role not found" };
            }

            IList<Claim> claims=await _roleRepository.GetRoleClaims(role);
            if (claims.Count==0)
            {
                return new BaseResponce { IsSuccess = true, Message = "No claim found against that role." };
            }
            List<ClaimDTO> ClaimList = new List<ClaimDTO>();
            foreach (Claim claim in claims)
            {
               ActionDTO actions= JsonSerializer.Deserialize<ActionDTO>(claim.Value);
                ClaimList.Add(new ClaimDTO { Type = claim.Type, Value = actions });
            }
            return new GenericResponce { IsSuccess = true, Message = "Claims fetched successfully", Data = ClaimList };


        }

        public Task<BaseResponce> GetClaimsByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponce> GetRoleById(string Id)
        {
            AppRole Role= await _roleRepository.GetRoleById(Id);
            if(Role==null)
            {
                return new BaseResponce { IsSuccess = true, Message = "Role not found" };
            }
            return new GenericResponce { IsSuccess = true, Message = "Role fetched successfully", Data = _mapper.Map<RoleDTO>(Role) };

       
        }

        public async Task<AppRole> GetRoleByName(string Name)
        {
           return await _roleRepository.GetRoleByName(Name);
        }

        public async Task<BaseResponce> GetRoleByUser(string UserId)
        {
            AppUser User = await _userRepository.GetUserById(UserId);
            if (User == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "User not found" };
            }
            IList<string> roles = await _roleRepository.GetUserRoles(User);
            if (roles == null)
            {
                return new BaseResponce { IsSuccess = true, Message = "No role found" };
            }
            return new GenericResponce { IsSuccess = true, Message = "Roles fetched successfully", Data = roles.ToList() };
        }

        public async Task<IList<Claim>> GetRoleClaims(AppRole Role)
        {
           return  await _roleRepository.GetRoleClaims(Role);
        }

        public async Task<List<string>> GetUserRoles(string UserId )
        {
            AppUser User = await _userRepository.GetUserById(UserId);
          
            IList<string> roles=await _roleRepository.GetUserRoles(User);
            return  roles.ToList();
          
        }

        public async Task<BaseResponce> GetUsersByRole(string Id)
        {
           AppRole role=await _roleRepository.GetRoleById(Id);
            if (role == null)
            {
                return new BaseResponce { IsSuccess = true, Message = "Role not found" };
            }

           IList<AppUser> Users=await _roleRepository.GetUsersByRole(role.Name);
            if (Users == null)
            {
                return new BaseResponce { IsSuccess = true, Message = "No user found against that role." };
            }
            return new GenericResponce { IsSuccess = true, Message = "Users fetched successfully", Data = Users.Select(x => _mapper.Map<UserDTO>(x)).ToList() };
        }

        public async Task<BaseResponce> RemoveClaimsFromRole(string RoleId,string ClaimType)
        {

             AppRole Role =await _roleRepository.GetRoleById(RoleId);
            if (Role == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Role not found" };
            }
            IList<Claim> claims = await _roleRepository.GetRoleClaims(Role);
            Claim? targetClaim = claims.FirstOrDefault(x => x.Type == ClaimType);
            if (targetClaim is Claim)
            {
                IdentityResult result = await _roleRepository.DeleteRoleClaim(Role, targetClaim);
                if (!result.Succeeded)
                {
                    return new BaseResponce { IsSuccess = false, Message = "failed to remove claim from role", Errors = result.Errors.Select(x => x.Description).ToList() };
                }
                return new BaseResponce { IsSuccess = true, Message = "Claim removed from role successfully" };
            };
            return new BaseResponce { IsSuccess = false, Message = "specified claim not found against that role." };
       
        }

        public async Task<BaseResponce> RemoveUserFromRole(string UserId, string RoleName)
        {
           AppUser User =await _userRepository.GetUserById(UserId);
            if(User==null)
            {
                return new BaseResponce { IsSuccess = false, Message = "User not found" };
            }
            IdentityResult result = await _roleRepository.RemoveUserFromRole(User, RoleName);
            if (!result.Succeeded)
            {
                return new BaseResponce { IsSuccess = false, Message = "failed to remove user from role", Errors = result.Errors.Select(x => x.Description).ToList() };
            }
            return new BaseResponce { IsSuccess = true, Message = "User removed from role successfully" };
        }

        public async Task<BaseResponce> UpdateRole(RoleDTO RoleData)
        {
            AppRole Role=_mapper.Map<AppRole>(RoleData);
            IdentityResult result =await _roleRepository.UpdateRole(Role);
            if (!result.Succeeded)
            {
                return new BaseResponce { IsSuccess = false, Message = "failed to update role", Errors = result.Errors.Select(x => x.Description).ToList() };
            }
            return new BaseResponce { IsSuccess = true, Message = "Role updated successfully" };
        }

        public async Task<BaseResponce> UpdateRoleClaims(RoleWithClaimsDTO RoleClaims)
        {
            AppRole role =await _roleRepository.GetRoleById(RoleClaims.Role.Id);
            if (role == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Role not found" };
            }
            //remove all claims of role
            IList<Claim> claims = await _roleRepository.GetRoleClaims(role);
            foreach (Claim claim in claims)
            {
                IdentityResult result =await _roleRepository.DeleteRoleClaim(role, claim);
                if (!result.Succeeded)
                {
                    return new BaseResponce { IsSuccess = false, Message = "failed to update role", Errors = result.Errors.Select(x => x.Description).ToList() };
                }
            }

            //add new claims in role
            foreach (ClaimDTO claim in RoleClaims.Claims)
            {
                string ClaimValue = JsonSerializer.Serialize(claim.Value);
                IdentityResult result  = await _roleRepository.AddRoleClaim(role, new Claim(claim.Type, ClaimValue));
                if (!result.Succeeded)
                {
                    return new BaseResponce { IsSuccess = false, Message = "failed to update role", Errors = result.Errors.Select(x => x.Description).ToList() };
                }
            }
                
            return new BaseResponce { IsSuccess = true, Message = "Claims updated in role successfully" };

        }
    }
}
