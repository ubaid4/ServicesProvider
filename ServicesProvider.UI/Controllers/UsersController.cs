using ServicesProvider.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.DTOs.Users;
using ServicesProvider.Core.Enums;
using ServicesProvider.Core.ServicInterfaces;
using ServicesProvider.UI.Authorization.Attributes;

namespace ServicesProvider.UI.Controllers
{
    public class UsersController :BaseController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [AppPermission(AppModules.Users,ModuleAction.View)]
        [HttpGet("/GetById/{UserId:required:appGuid}")]
        public async Task<ActionResult> GetUser(string UserId)
        {
            BaseResponce responce = await _userService.GetUser(UserId);
            if (!responce.IsSuccess)
            {
               return BadRequest(responce);
            }
            return Ok(responce);

        }

        [AppPermission(AppModules.Users,ModuleAction.View)]
        [HttpGet("/GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            BaseResponce responce = await _userService.GetAllUsers();
            if (!responce.IsSuccess)
            {
                return BadRequest(responce);
            }
            return Ok(responce);

        }

    }
}
