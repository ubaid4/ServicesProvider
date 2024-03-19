using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Shared
{
    public record GenericResponce: BaseResponce
    {
       public object? Data { get; init; }
    }
}
