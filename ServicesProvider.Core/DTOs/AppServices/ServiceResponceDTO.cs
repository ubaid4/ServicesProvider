using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Services
{
    public class ServiceResponceDTO
    {

        public string Id { get; set; }


        public string EnglishName { get; set; }

        public string ArabicName { get; set; }


        public string EnglishDescription { get; set; }

        public string ArabicDescription { get; set; }


        public string IconUrl { get; set; }

        public int Price { get; set; }

        public int? OrderNumber { get; set; }


        public int? Status { get; set; }

        public string CategoryId { get; set; }

        public string CoreActivityId { get; set; }
    }
}
