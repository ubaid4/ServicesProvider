using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.CoreActivities;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.Services;
using ServicesProvider.Core.ServicInterfaces;

namespace AuthJwt.UI.Controllers
{
    public class CoreActivityController : BaseController
    {
        private readonly ICoreActivityService _coreActivityService;
        public CoreActivityController( ICoreActivityService coreActivityService)
        {
            _coreActivityService = coreActivityService;
        }
        [HttpGet("GetById/{Id:required}")]
        public async Task<IActionResult> GetById(string Id)
        {
            BaseResponce res = await _coreActivityService.GetCoreActivity(Id);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }


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

        [HttpGet("GetAllByCategory/{CategoryId:required}")]
        public async Task<IActionResult> GetAllByCategory(string CategoryId)
        {
            BaseResponce res = await _coreActivityService.GetAllCoreActivitiesByCategory(CategoryId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNew(CoreActivityDTO CoreActivity)
        {
            BaseResponce res = await _coreActivityService.AddCoreActivity(CoreActivity);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);

        }
        [HttpDelete("Delete/{CoreActivity:required}")]
        public async Task<IActionResult> Delete(string CoreActivity)
        {
            BaseResponce res = await _coreActivityService.DeleteCoreActivity(CoreActivity);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CoreActivityDTO CoreActivity)
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
