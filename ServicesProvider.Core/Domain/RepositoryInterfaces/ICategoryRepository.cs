using ServicesProvider.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.RepositoryInterfaces
{
    public interface ICategoryRepository : IGeneric<Category>
    {
        Task<Category> GetChildCoreActivities(Guid categoryId);
        Task<List<Category>> CategoriesByStatus(int status);
    }
}
