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
    public class ServiceRepository : GenericRepository<AppServices>, IAppServicesRepository
    {
        private readonly AppDbContext _context;
        public ServiceRepository(AppDbContext context) : base(context)
        {

            _context = context;

        }

        public async Task<IList<AppServices>> GetServicesByCategoryId(Guid CategoryId)
        {
           return await _context.Services.Where(x => x.CategoryId == CategoryId).ToListAsync();
        }

        public async Task<IList<AppServices>> GetServicesByCoreActivity(Guid CoreActivityId)
        {
           return await _context.Services.Where(x => x.CoreActivityId == CoreActivityId).ToListAsync();

        }
    }
}
