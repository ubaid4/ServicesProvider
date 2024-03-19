using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.ServicInterfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public JwtService(IConfiguration configuration,IUserRepository userRepository)
        {
            _configuration = configuration;

            _userRepository = userRepository;
        }

     

        public async Task<(string, DateTimeOffset)> GenerateJwtToken(AppUser User)
        {
            DateTime expiration = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration.GetSection("Jwt")["Access_Token_Expiration_Minutes"]));
            SymmetricSecurityKey secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt")["Key"]));
            SigningCredentials cred = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha512Signature);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, User.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, User.UserName),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim(ClaimTypes.Expiration,"anyValue"),
             
            };
            //add Role and claims in token if Needed
            /*IList<string> roles = await _roleService.GetUserRoles(UserId);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }*/

            // descriptor method
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {  
                 
                Subject = new ClaimsIdentity(claims),
                Expires = expiration,
                SigningCredentials = cred,
                Issuer = _configuration.GetSection("Jwt")["Issuer"],
                Audience = _configuration.GetSection("Jwt")["Audience"],

            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var tokenGen = handler.CreateToken(descriptor);
            string token = handler.WriteToken(tokenGen);


            return (token,expiration);
        }

     

        public async Task<(string, DateTimeOffset)> GenerateRefreshToken(AppUser User)
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            string refreshToken = Convert.ToBase64String(randomNumber);
            DateTime expires = DateTime.Now.AddHours(Convert.ToDouble(_configuration.GetSection("Jwt")["Refresh_Token_Expiration_Hours"]));
            User.RefreshToken = refreshToken;
            User.RefreshTokenExpiration = expires;
            await _userRepository.UpdateUser(User);
            return (refreshToken, expires);
           

        }

        public bool IsRefreshTokenValid(AppUser User, string RefreshToken)
        {
           return RefreshToken !=null && User.RefreshToken==RefreshToken && User.RefreshTokenExpiration>DateTimeOffset.Now.DateTime;
           
        }
    }
}
