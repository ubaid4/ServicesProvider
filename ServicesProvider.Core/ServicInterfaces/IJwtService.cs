using ServicesProvider.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.ServicInterfaces
{
    public interface IJwtService
    {

        /// <summary>
        /// this method returns 2 values, first is the token and the second is the expiration date.
        /// this approach is called touple which helps to return multiple values from a function.
        /// you can see the usage of this method in the AccountService class.
        /// you can see the impilimentation of this method in the JwtService class.
        /// </summary>
        /// <returns> Access Token and Expiration DateTime</returns>
        Task<(string, DateTimeOffset)> GenerateJwtToken(AppUser User);

        /// <summary>
        /// this method returns 2 values, first is the token and the second is the expiration date.
        /// this approach is called touple which helps to return multiple values from a function.
        /// you can see the usage of this method in the AccountService class.
        /// you can see the impilimentation of this method in the JwtService class.
        /// </summary>
        /// <returns> Refresh Token and Expiration DateTime</returns>
        Task<(string, DateTimeOffset)> GenerateRefreshToken(AppUser User);
        bool IsRefreshTokenValid(AppUser User, string RefreshToken);
       
    }
}
