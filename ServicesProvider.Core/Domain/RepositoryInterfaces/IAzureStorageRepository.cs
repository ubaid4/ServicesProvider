using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.RepositoryInterfaces
{
    public interface IAzureStorageRepository
    {
        Task<string> UploadFile(IFormFile File,string AzureConnectionStrin,string Container);
       


    }
}
