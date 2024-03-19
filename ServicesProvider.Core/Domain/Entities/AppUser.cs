using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using ServicesProvider.Core.DTOs.Shared;
namespace ServicesProvider.Core.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string ProfileImage { get; set; }

        public string? RefreshToken { get; set; }
        public DateTimeOffset? RefreshTokenExpiration { get; set; }


    }
}
