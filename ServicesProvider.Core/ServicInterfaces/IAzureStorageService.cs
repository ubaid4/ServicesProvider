using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.ServicInterfaces
{
    public interface IAzureStorageService
    {
        Task<string> UploadSingleFile(IFormFile File);
       

 
    }
}
