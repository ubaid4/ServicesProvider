using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.DTOs.Shared
{
    public record BlobDTO
    {
        public bool IsSuccess { get; set; }
        public string? Uri { get; set; }
        public string? Name { get; set; }
        public string? ContentType { get; set; }
        public string? Error { get; set; }
        public Stream? ContentStream { get; set; }

    }
}
