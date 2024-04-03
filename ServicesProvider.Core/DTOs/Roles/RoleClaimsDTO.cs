using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Roles
{
    public record RoleClaimsDTO
    {
       public string RoleId { get; set; }
       
      public List<ClaimDTO> Permissions { get; set; }
    }
}
