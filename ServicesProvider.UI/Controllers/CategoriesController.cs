using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.Enums;
using ServicesProvider.Core.ServicInterfaces;
using ServicesProvider.UI.Authorization.Attributes;


namespace AuthJwt.UI.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly string _azureConnectionString;
        public CategoriesController(ICategoryService categoryService, IConfiguration configuration) 
        {
            _categoryService = categoryService;
            _azureConnectionString = configuration["AzureBlobStorage:ConnectionString"];
        }
        //[AppPermission(AppModules.Categories,ModuleAction.View)]
        [HttpGet("GetById/{Id:required}")]
        public async Task<IActionResult> GetById(string Id)
        {
            BaseResponce res=await _categoryService.GetCategory(Id);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [HttpGet("GetChildCoreActivities/{categoryId:required}")]
        public async Task<IActionResult> GetChildCoreActivities(string categoryId)
        {
            BaseResponce res=await _categoryService.GetChildCoreActivities(categoryId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        //[AppPermission(AppModules.Categories,ModuleAction.View)]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            BaseResponce res=await _categoryService.GetAllCategories();
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        //[AppPermission(AppModules.Categories,ModuleAction.Add)]
     
        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNew(CategoryDTO category)
        {
            BaseResponce res=await _categoryService.AddCategory(category);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        //[AppPermission(AppModules.Categories,ModuleAction.Delete)]
        [HttpDelete("Delete/{categoryId}")]
        public async Task<IActionResult> Delete(string categoryId)
        {
            BaseResponce res=await _categoryService.DeleteCategory(categoryId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        //[AppPermission(AppModules.Categories,ModuleAction.Edit)]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(CategoryDTO category)
        {
            BaseResponce res=await _categoryService.UpdateCategory(category);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
     
    }
}
