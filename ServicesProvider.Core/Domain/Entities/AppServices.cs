using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.Entities
{
    public class AppServices
    {
        public AppServices()

        {

            //if this property is not attached to the request, it will be set to the default value,
            //if it is attached to the request, then it will be overwritten by the attached value of the request
            Id = Guid.NewGuid();
        }


        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }

        public string Description { get; set; }
        public string ArabicDescription { get; set; }

        public string ImageUrl { get; set; }
        public int Price { get; set; }

        public int RenderOrder { get; set; }
        public int? Status { get; set; } 
        public Guid CategoryId { get; set; }
        public Guid CoreActivityId { get; set; }

        
    
    }
}
