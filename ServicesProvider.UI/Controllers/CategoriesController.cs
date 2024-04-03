using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.Enums;
using ServicesProvider.Core.ServicInterfaces;
using ServicesProvider.UI.Authorization.Attributes;
using ServicesProvider.UI.Controllers;
using ServicesProvider.UI.Filters;


namespace ServicesProvider.UI.Controllers
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

        [AppPermission(AppModules.Categories,ModuleAction.View)]
        [HttpGet("GetById/{Id:required:appGuid}")]
        public async Task<IActionResult> GetById(string Id)
        {
            BaseResponce res=await _categoryService.GetCategory(Id);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [AppPermission(AppModules.Categories, ModuleAction.View)]
        [HttpGet("GetChildCoreActivities/{categoryId:required:appGuid}")]
        public async Task<IActionResult> GetChildCoreActivities(string categoryId)
        {
            BaseResponce res=await _categoryService.GetChildCoreActivities(categoryId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [AppPermission(AppModules.Categories,ModuleAction.View)]
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
        [AppPermission(AppModules.Categories,ModuleAction.Add)]
        [TypeFilter(typeof(AzureBlobUrlValidation))]
        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNew(AddCategoryDTO category)
        {
            BaseResponce res=await _categoryService.AddCategory(category);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [AppPermission(AppModules.Categories,ModuleAction.Delete)]
        [HttpDelete("Delete/{categoryId:required:appGuid}")]
        public async Task<IActionResult> Delete(string categoryId)
        {
            BaseResponce res=await _categoryService.DeleteCategory(categoryId);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [AppPermission(AppModules.Categories,ModuleAction.Edit)]
        [TypeFilter(typeof(AzureBlobUrlValidation))]

        [HttpPut("Update")]
        public async Task<IActionResult> Update(EditCategoryDTO category)
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
