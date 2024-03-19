using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.ServicInterfaces
{
    public interface IUserService
    {
        Task<AppUser> GetUserByName(string UserName);
        Task<AppUser> GetUserById(string Id);
        Task<AppUser> GetUserByEmail(string Email);
        Task<BaseResponce> GetUser(string Id);
        Task<BaseResponce> GetAllUsers();
        Task<GenericResponce> AddUser(UserDTO User);
        Task<GenericResponce> UpdateUser(UserDTO User);
        Task<GenericResponce> DeleteUser(string Id);

        Task<bool> IsUserAllowed(string UserId, string Module , string Action);


    }
}
