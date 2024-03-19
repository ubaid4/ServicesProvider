using AuthJwt.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.DTOs.Roles;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.Enums;
using ServicesProvider.Core.ServicInterfaces;
using System.Security.Claims;

namespace ServicesProvider.UI.Controllers
{
    public class RolesController : BaseController
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            BaseResponce res = await _roleService.GetAllRoles();
            if(!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet("Get/{Id:required}")]
        public async Task<IActionResult> Get(string Id)
        {
            BaseResponce res = await _roleService.GetRoleById(Id);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RoleDTO role)
        {
            BaseResponce res = await _roleService.AddRole(role);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [HttpDelete("Delete/{Id:required}")]
        public async Task<IActionResult> Delete(string Id)
        {
            BaseResponce res = await _roleService.DeleteRole(Id);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [HttpPost("AddUserInRole")]
        public async Task<IActionResult> AddUserInRole(string UserId,string RoleName)
        {
            BaseResponce res = await _roleService.AddUserInRole(UserId, RoleName);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [HttpDelete("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string UserId, string RoleName)
        {
            BaseResponce res = await _roleService.RemoveUserFromRole(UserId, RoleName);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] RoleDTO role)
        {
            BaseResponce res = await _roleService.UpdateRole(role);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet("GetUserRoles/{UserId:required}")]
        public async Task<IActionResult> GetUserRoles(string UserId)
        {
            
            BaseResponce res = await _roleService.GetRoleByUser(UserId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet("GetUsersByRole/{RoleId:required}")]
        public async Task<IActionResult> GetUsersByRole(string RoleId)
        {
            BaseResponce res = await _roleService.GetUsersByRole(RoleId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("AddClaimsInExistingRole")]
        public async Task<IActionResult> AddClaimsInRole(RoleClaimsDTO claim)
        {
            BaseResponce res  =await _roleService.AddClaimsInExistingRole(claim);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("AddRoleWithClaims")]
        public async Task<IActionResult> AddRoleWithClaims(RoleWithClaimsDTO RoleClaims)
        {
            BaseResponce res = await _roleService.AddRoleWithClaims(RoleClaims);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet("GetClaimsByRole/{RoleId:required}")]
        public async Task<IActionResult> GetClaimsByRole(string RoleId)
        {
            BaseResponce res = await _roleService.GetClaimsByRole(RoleId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut("UpdateRoleClaims")]
        public async Task<IActionResult> UpdateRoleClaims(RoleWithClaimsDTO RoleClaims)
        {
            BaseResponce res = await _roleService.UpdateRoleClaims(RoleClaims);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete("RemoveClaimFromRole/{RoleId:required}/{ClaimType:required}")]
        public async Task<IActionResult> RemoveClaimFromRole(string RoleId, string ClaimType)
        {

            var UserInfoFromToken= User;
            bool f=UserInfoFromToken.IsInRole("admin");
            BaseResponce res = await _roleService.RemoveClaimsFromRole(RoleId, ClaimType);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }



        [HttpGet("GetClaimsType")]
        public async Task<IActionResult> GetModulesForClaim()
        {
            return Ok(new GenericResponce { IsSuccess = true, Data = Enum.GetNames(typeof(AppModules)).ToList(),Message ="Modules fetched succesfully" });
           
        }



       
    }
}
