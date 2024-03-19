using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Roles
{
    public record RoleDTO
    {
        public string? Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(50, MinimumLength = 3,ErrorMessage ="Name charactors should be form 3 to 10")]
        public string Name { get; init; }
        
    }
}
