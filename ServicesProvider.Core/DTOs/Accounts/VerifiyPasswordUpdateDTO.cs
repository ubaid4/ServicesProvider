using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Accounts
{
    public record VerifiyPasswordUpdateDTO
    {
        [Required(ErrorMessage = "User Id is required.")]
        [RegularExpression(@"(?i)\b[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\b", ErrorMessage = "UserId must be in GUID format")]

        public string UserId { get; set; }
        [Required(ErrorMessage = "Token is required.")]
        public string Token { get; set; }
        [Required(ErrorMessage = "New Password is required.")]
        public string NewPassword { get; set; }
    }
}
