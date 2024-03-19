using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Roles
{
    public record ClaimDTO
    {
        public string Type { get; set; }
        public ActionDTO Value { get; set; }
    }
}
