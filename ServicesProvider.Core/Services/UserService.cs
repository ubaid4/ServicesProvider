using AutoMapper;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.DTOs.Roles;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.DTOs.Users;
using ServicesProvider.Core.ServicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper, IRoleService roleService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _roleService = roleService;
        }

        public Task<GenericResponce> AddUser(UserDTO User)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponce> DeleteUser(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponce> GetAllUsers()
        {

            List<AppUser> users =await _userRepository.GetAllUsers();
            if (users == null)
            {
                return new BaseResponce() { IsSuccess = true, Message = "No user found" };
            }
            return new GenericResponce() { IsSuccess = true, Message = "users fetched successfully", Data = users.Select(x => _mapper.Map<UserDTO>(x) )};
        }

        public async Task<BaseResponce> GetUser(string Id)
        {
            AppUser user = await _userRepository.GetUserById(Id);

            if (user == null)
            {
               return new BaseResponce(){ IsSuccess = true, Message = "User not found" };
            }
            return new GenericResponce() { IsSuccess = true, Message = "Got user successfully", Data = _mapper.Map<UserDTO>(user) };
        
            
            
        }

        public async Task<AppUser> GetUserByEmail(string Email)
        {
            AppUser user = await _userRepository.GetUserByEmail(Email);
            return user;
        }

        public async Task<AppUser> GetUserById(string Id)
        {
            AppUser user = await _userRepository.GetUserById(Id);
            return user;
        }

        public async Task<AppUser> GetUserByName(string UserName)
        {
           AppUser user = await _userRepository.GetUserByName(UserName);
            return user;
        }

        public async Task<bool> IsUserAllowed(string UserId, string Module, string Action)
        {
            AppUser User=await _userRepository.GetUserById(UserId);
            if(User==null)
            {
                return false;
            }
            List<string> Roles = await _roleService.GetUserRoles(UserId);
            if(Roles==null)
            {
                return false;
            }
            //Check if user has permission
            foreach(string Role in Roles)
            {
               AppRole AppRole=await _roleService.GetRoleByName(Role);
               IList<Claim> claims= await _roleService.GetRoleClaims(AppRole);
                foreach(Claim claim in claims)
                {
                    if (claim.Type == Module)
                    {
                        ActionDTO permissions = JsonSerializer.Deserialize<ActionDTO>(claim.Value);
                        bool isActionAllowed = bool.Parse(permissions.GetType().GetProperty(Action).GetValue(permissions, null).ToString());
                        if (isActionAllowed)
                        {
                            return true;

                        }


                    }
                }
            }

            return false;
        }

        public Task<GenericResponce> UpdateUser(UserDTO User)
        {

            throw new NotImplementedException();
        }
    }
}
