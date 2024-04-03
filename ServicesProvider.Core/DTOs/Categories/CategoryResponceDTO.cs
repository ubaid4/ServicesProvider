using ServicesProvider.Core.DTOs.CoreActivities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Categories
{
    public class CategoryResponceDTO
    {
        public string Id { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public int OrderNumber { get; set; }
        public int Status { get; set; }
        public int Size { get; set; }

        public string? IconURL { get; set; }

    }
}
