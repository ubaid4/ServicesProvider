using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Roles
{
    public class RoleWithClaimsDTO
    {
        public RoleDTO Role { get; set; }

        public List<ClaimDTO> Claims { get; set; }

        
    }
}
