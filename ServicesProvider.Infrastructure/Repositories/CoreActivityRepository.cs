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
    public class CoreActivityRepository : GenericRepository<CoreActivity> ,ICoreActivityRepository
    {
        private readonly AppDbContext _context;
        public CoreActivityRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }
        public async Task<IList<CoreActivity>> GetCoreActivitiesByCategoryId(Guid CategoryId)
        {
            return await _context.CoreActivities.Where(x => x.CategoryId == CategoryId).ToListAsync();
        }

       
    }
}
