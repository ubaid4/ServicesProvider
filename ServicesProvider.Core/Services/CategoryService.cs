using AutoMapper;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.ServicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Services
{
    public class CategoryService : ICategoryService
    {
       // private readonly IGeneric<Category> _genericRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _autoMapper;
        private readonly IAzureStorageService _azureStorageService;
        public CategoryService( IGeneric<Category> genericRepository,IMapper autoMapper,ICategoryRepository categoryRepository, IAzureStorageService azureStorageService ) 
        { 
            //_genericRepository = genericRepository;
            _autoMapper = autoMapper;
            _categoryRepository = categoryRepository;
            _azureStorageService = azureStorageService;

        
        }
        public async Task<BaseResponce> AddCategory(AddCategoryDTO categoryData)
        {
            //categoryData.Id = Guid.NewGuid().ToString();
            Category Category=_autoMapper.Map<Category>(categoryData);
          
            //Category.IconUrl = await _azureStorageService.UploadSingleFile(categoryData.Icon) ?? "DefaultCategoryIcon.png";
            //Category res=await _genericRepository.Add(Category);
            Category res =await _categoryRepository.Add(Category);
            if (res == null)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Failed to add category" };
            }
            CategoryResponceDTO data =_autoMapper.Map<CategoryResponceDTO>(res);
            return new GenericResponce() { IsSuccess = true, Message = "Category added successfully" ,Data=data};
            
        }

        public async Task<BaseResponce> DeleteCategory(string categoryId)
        {
            Category category=await _categoryRepository.GetById(Guid.Parse(categoryId));
            if (category == null)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Category not found" };
            }
            Category res=await _categoryRepository.Delete(category);
            if (res == null)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Failed to delete category" };
            }
            return new BaseResponce() { IsSuccess = true, Message = "Category deleted successfully" };

        }

        public async Task<BaseResponce> GetAllCategories()
        {
            List<Category> categories=await _categoryRepository.GetAll();
            if (categories == null)
            {
                return new BaseResponce() { IsSuccess = true, Message = "No category found" };
            }
            return new GenericResponce() { IsSuccess = true, Message = "categories fetched successfully", Data = categories.Select(x => _autoMapper.Map<EditCategoryDTO>(x)) };
        }

        public async Task<BaseResponce> GetCategory(string categoryId)
        {
            Category Category = await _categoryRepository.GetById(Guid.Parse(categoryId));
            if (Category == null)
            {
                return new BaseResponce() { IsSuccess = true, Message = "Category not found" };
            }
            return new GenericResponce() { IsSuccess = true, Message = "Category fetched successfully", Data = _autoMapper.Map<EditCategoryDTO>(Category) };
        }

        public async Task<BaseResponce> GetChildCoreActivities(string categoryId)
        {
            Category Category = await _categoryRepository.GetChildCoreActivities(Guid.Parse(categoryId));
            if (Category == null)
            {
                return new BaseResponce() { IsSuccess = true, Message = "Category not found" };
            }
            return new GenericResponce() { IsSuccess = true, Message = "Category fetched successfully", Data = _autoMapper.Map<CategoryWithChildResponceDTO>(Category) };

        }

        public async Task<BaseResponce> UpdateCategory(EditCategoryDTO category)
        {

            Category Category=await _categoryRepository.Update(_autoMapper.Map<Category>(category));
            if (Category == null)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Failed to update category" };
            }
            return new GenericResponce() { IsSuccess = true, Message = "Category updated successfully",Data=_autoMapper.Map<EditCategoryDTO>(Category)  };
        }
    }
}
