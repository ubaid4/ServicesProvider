using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.Entities
{
    public class CoreActivity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string? Description { get; set; }
        public int RenderOrder { get; set; }

        public int Status { get; set; }

        public int Size { get; set; }
        public Guid CategoryId { get; set; }
       
   
    }
}
