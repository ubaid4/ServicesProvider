using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Accounts
{
    public record SignInResponceDTO : BaseResponce
    {
    
       public Guid UserId { get; set; }
       public string Token { get; set; }
        public DateTimeOffset? TokenExpiration { get; set; }
       public string? RefreshToken { get; set; }
        public DateTimeOffset? RefreshTokenExpiration { get; set; }

    }
}
