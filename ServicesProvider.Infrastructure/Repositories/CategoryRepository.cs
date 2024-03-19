using Microsoft.EntityFrameworkCore;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Category>> CategoriesByStatus(int status)
        {
            throw new NotImplementedException();
        }
      
       
        public async Task<Category> GetChildCoreActivities(Guid categoryId)
        {
            return await  _dbContext.Categories.Include(x => x.Activities).Where(x => x.Id == categoryId).FirstOrDefaultAsync();

        }
    }
}
