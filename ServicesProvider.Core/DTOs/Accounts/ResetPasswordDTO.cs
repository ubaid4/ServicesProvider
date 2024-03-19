using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Accounts
{
    public record ResetPasswordDTO
    {
        [Required(ErrorMessage = "User Id is required.")]
        [RegularExpression(@"(?i)\b[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\b", ErrorMessage = "UserId must be in GUID format")]

        public string UserId { get; set; }

        [Required(ErrorMessage = "Current Password is required.")]
        public string CurrentPassword { get; set; }

       
        [Required(ErrorMessage = "New Password is required.")]
        public string NewPassword { get; set; }

    }
}
