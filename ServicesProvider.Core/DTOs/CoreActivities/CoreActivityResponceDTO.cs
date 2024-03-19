using ServicesProvider.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.CoreActivities
{
    public class CoreActivityResponceDTO
    {
        public string? Id { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public int OrderNumber { get; set; }
        public int Status { get; set; }
        public int Size { get; set; }
        public Category Category { get; set; }
    }
}
