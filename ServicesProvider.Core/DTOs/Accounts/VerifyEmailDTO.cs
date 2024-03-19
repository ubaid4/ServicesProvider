using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Accounts
{
    public class VerifyEmailDTO
    {
        [Required(ErrorMessage = "User Id is required.")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Token is required.")]
        public string Token { get; set; }
    }
}
