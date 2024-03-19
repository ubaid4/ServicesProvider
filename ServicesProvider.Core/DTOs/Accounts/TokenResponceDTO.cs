using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Accounts
{
    public record TokenResponceDTO : BaseResponce
    {
        public string UserId { get; init; }
        public string Token { get; init; }
        public DateTime Expiration { get; init; }
    }
}
