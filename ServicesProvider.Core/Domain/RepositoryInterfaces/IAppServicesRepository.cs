using ServicesProvider.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.RepositoryInterfaces
{
    public interface IAppServicesRepository : IGeneric<AppServices>
    {
        Task<IList<AppServices>> GetServicesByCategoryId(Guid CategoryId);
        Task<IList<AppServices>> GetServicesByCoreActivity(Guid CoreActivityId);

    }
}
