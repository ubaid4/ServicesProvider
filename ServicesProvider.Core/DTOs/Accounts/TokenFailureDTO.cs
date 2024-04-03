using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Accounts
{
    public record TokenFailureDTO:BaseResponce
    {
        public bool IsTokenExipred { get; set; }
        public bool IsTokenNotProvided { get; set; }
        public bool IsTokenNotAuthorized { get; set; }

    }
}
