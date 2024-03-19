using ServicesProvider.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.RepositoryInterfaces
{
    public interface ICoreActivityRepository : IGeneric<CoreActivity>
    {
        Task<IList<CoreActivity>> GetCoreActivitiesByCategoryId(Guid CategoryId);
    }
}
