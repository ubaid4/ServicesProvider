using ServicesProvider.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<AppUser> GetUserByName(string UserName);
        Task<AppUser> GetUserById(string Id);
        Task<AppUser> GetUserByEmail(string Email);
        Task<AppUser> UpdateUser(AppUser User);
        Task<List<AppUser>> GetAllUsers(); 
    }
}
