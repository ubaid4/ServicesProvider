using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.CoreActivities
{
    public class CoreActivityEditDTO
    {
        public CoreActivityEditDTO()
        {
            //if this property is not attached to the request, it will be set to the default value,
            //if it is attached to the request, then it will be overwritten by the attached value of the request
            //this is a way to set default values for the properties of the DTO, if the request does not contain them and DB does not allow null values
            IconUrl = "https://azurestorage44.blob.core.windows.net/servicesprovider/customfolder/e612c1bf-3efd-4537-9801-70806bc9e52b-icons8-home-24.png";

        }
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

        public string? IconUrl { get; set; }


        [Required(ErrorMessage = "Category is required")]
        public string CategoryId { get; set; }
    }
}
