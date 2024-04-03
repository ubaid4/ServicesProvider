using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.CoreActivities;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.Enums;
using ServicesProvider.Core.Services;
using ServicesProvider.Core.ServicInterfaces;
using ServicesProvider.UI.Authorization.Attributes;
using ServicesProvider.UI.Filters;

namespace ServicesProvider.UI.Controllers
{
    public class CoreActivityController : BaseController
    {
        private readonly ICoreActivityService _coreActivityService;
        public CoreActivityController( ICoreActivityService coreActivityService)
        {
            _coreActivityService = coreActivityService;
        }

        [AppPermission(AppModules.CoreActivities, ModuleAction.View)]
        [HttpGet("GetById/{Id:required:appGuid}")]
        public async Task<IActionResult> GetById(string Id)
        {
            BaseResponce res = await _coreActivityService.GetCoreActivity(Id);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [AppPermission(AppModules.CoreActivities, ModuleAction.View)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            BaseResponce res = await _coreActivityService.GetAllCoreActivities();
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [AppPermission(AppModules.CoreActivities, ModuleAction.View)]
        [HttpGet("GetAllByCategory/{CategoryId:required:appGuid}")]
        public async Task<IActionResult> GetAllByCategory(string CategoryId)
        {
            BaseResponce res = await _coreActivityService.GetAllCoreActivitiesByCategory(CategoryId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [AppPermission(AppModules.CoreActivities, ModuleAction.Add)]
        [TypeFilter(typeof(AzureBlobUrlValidation))]
        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNew(CoreActivityAddDTO CoreActivity)
        {
            BaseResponce res = await _coreActivityService.AddCoreActivity(CoreActivity);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);

        }
        [AppPermission(AppModules.CoreActivities, ModuleAction.Delete)]
        [HttpDelete("Delete/{CoreActivityId:required:appGuid}")]
        public async Task<IActionResult> Delete(string CoreActivityId)
        {
            BaseResponce res = await _coreActivityService.DeleteCoreActivity(CoreActivityId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [AppPermission(AppModules.CoreActivities, ModuleAction.Edit)]
        [TypeFilter(typeof(AzureBlobUrlValidation))]

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CoreActivityEditDTO CoreActivity)
        {
            BaseResponce res = await _coreActivityService.UpdateCoreActivity(CoreActivity);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

    }
}
