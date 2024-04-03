using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            //if this property is not attached to the request, it will be set to the default value,
            //if it is attached to the request, then it will be overwritten by the attached value of the request
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public int RenderOrder { get; set; }
        public int Status { get; set; }
        public int Size { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<CoreActivity>? Activities { get; set; }
    }
}
