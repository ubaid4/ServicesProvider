using ServicesProvider.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Roles
{
    public class RoleWithClaimsInitializerDTO
    {
        public required AppRole Role { get; set; }
        public  required List<Claim> ClaimList { get; set; }  
    }
}
