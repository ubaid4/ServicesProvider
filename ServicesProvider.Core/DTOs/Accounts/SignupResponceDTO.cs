using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Accounts
{
    public record SignupResponceDTO : BaseResponce
    {
        public Guid? UserId { get; set; }
        public string? ConfirmationToken { get; set; }

        
    }
}
