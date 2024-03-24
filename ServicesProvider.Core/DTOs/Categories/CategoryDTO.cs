using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Categories
{
    public class CategoryDTO
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string EnglishName { get; set; }
        [Required(ErrorMessage = "ArabicName is required")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "OrderNumber is required")]
        [Range(1, 1000, ErrorMessage = "OrderNumber must be between 1 and 1000")]
        
        public int OrderNumber { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public int Status { get; set; }
        [Required(ErrorMessage = "Size is required")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Icon is required")]

        public IFormFile? Icon { get; set; }
    }
}
