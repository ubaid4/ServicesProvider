using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Shared
{
    public record UrlDTO
    {
        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }
    }
}
