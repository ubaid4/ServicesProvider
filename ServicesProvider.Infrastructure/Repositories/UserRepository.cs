using Microsoft.AspNetCore.Identity;
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
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        public UserRepository(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<AppUser> GetUserByName(string UserName)
        {
            return await _userManager.FindByNameAsync(UserName);
        }

        public async Task<AppUser> GetUserByEmail(string Email)
        {
            return await _userManager.FindByEmailAsync(Email);
        }

        public async Task<AppUser> GetUserById(string Id)
        {
            return await _userManager.FindByIdAsync(Id);
           
           
        }

        public async Task<List<AppUser>> GetAllUsers()
        { 
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> UpdateUser(AppUser User)
        {
            _context.Users.Update(User);
            await _context.SaveChangesAsync();
            return User;
        }
    }
}
