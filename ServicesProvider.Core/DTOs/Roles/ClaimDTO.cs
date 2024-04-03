using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Roles
{
    public record ClaimDTO
    {
        public string ModuleName { get; set; }
        public ActionDTO Permission { get; set; }
    }
}
