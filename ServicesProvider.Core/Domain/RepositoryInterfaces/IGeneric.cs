using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.RepositoryInterfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<T> Add(T Entity);
        Task<T> Update(T Entity);
        Task<T> Delete(T Entity);
        Task<T> GetById(Guid Id);
        Task<List<T>> GetAll();
    }
}
