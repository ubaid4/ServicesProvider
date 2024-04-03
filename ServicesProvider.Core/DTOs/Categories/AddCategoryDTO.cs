using ServicesProvider.Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Categories
{
    public class AddCategoryDTO
    {
        public AddCategoryDTO()
        {
            //if this property is not attached to the request, it will be set to the default value,
            //if it is attached to the request, then it will be overwritten by the attached value of the request
            //this is a way to set default values for the properties of the DTO, if the request does not contain them and DB does not allow null values
            IconUrl = SharedData.DefaultCategoryImageUrl; 
        }

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

        [Url(ErrorMessage = "IconUrl must be a valid URL")]
        public string? IconUrl { get; set; }
    }
}
