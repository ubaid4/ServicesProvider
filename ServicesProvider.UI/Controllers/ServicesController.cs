using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Services;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.Enums;
using ServicesProvider.Core.ServicInterfaces;
using ServicesProvider.UI.Authorization.Attributes;
using ServicesProvider.UI.Filters;

namespace ServicesProvider.UI.Controllers
{
    public class ServicesController : BaseController
    {
        private readonly IAppServicesService _appServicesService;


        public ServicesController(IAppServicesService appServicesService)
        {
            _appServicesService = appServicesService;
 
        }
        [AppPermission(AppModules.Services, ModuleAction.View)]
        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAllAppServices()
        {
            BaseResponce res = await _appServicesService.GetAllAppServices();
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [AppPermission(AppModules.Services, ModuleAction.View)]
        [HttpGet("GetService/{AppServiceId}")]
        public async Task<IActionResult> GetAppService(string AppServiceId)
        {
            BaseResponce res = await _appServicesService.GetAppService(AppServiceId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [AppPermission(AppModules.Services, ModuleAction.View)]
        [HttpGet("GetAllServicesByCategory/{CategoryId}")]
        public async Task<IActionResult> GetAllAppServicesByCategory(string CategoryId)
        {
            BaseResponce res = await _appServicesService.GetAllAppServicesByCategory(CategoryId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [AppPermission(AppModules.Services, ModuleAction.View)]
        [HttpGet("GetAllServicesByCoreActivity/{CoreActivityId}")]
        public async Task<IActionResult> GetAllAppServicesByCoreActivity(string CoreActivityId)
        {
            BaseResponce res = await _appServicesService.GetAllAppServicesByCoreActivity(CoreActivityId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [AppPermission(AppModules.Services, ModuleAction.Add)]
        [TypeFilter(typeof(AzureBlobUrlValidation))]
        [HttpPost("AddService")]
        public async Task<IActionResult> AddAppService(ServiceAddDTO AppService)
        {
            BaseResponce res = await _appServicesService.AddAppService(AppService);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [AppPermission(AppModules.Services, ModuleAction.Delete)]
        [HttpDelete("DeleteService/{AppServiceId:AppGuid}")]
        public async Task<IActionResult> DeleteAppService(string AppServiceId)
        {
            BaseResponce res = await _appServicesService.DeleteAppService(AppServiceId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [AppPermission(AppModules.Services, ModuleAction.Edit)]
        [TypeFilter(typeof(AzureBlobUrlValidation))]
        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateAppService(ServiceEditDTO AppService)
        {
            BaseResponce res = await _appServicesService.UpdateAppService(AppService);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
