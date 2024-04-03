using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.ServicInterfaces
{
    public interface ICategoryService
    {
        Task<BaseResponce> GetCategory(string categoryId);
        Task<BaseResponce> GetChildCoreActivities(string categoryId);
        Task<BaseResponce> GetAllCategories();
        Task<BaseResponce> AddCategory(AddCategoryDTO category);
        Task<BaseResponce> DeleteCategory(string categoryId);
        Task<BaseResponce> UpdateCategory(EditCategoryDTO category);
    }
}
