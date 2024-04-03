using Microsoft.AspNetCore.Http;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Domain.RepositoryInterfaces
{
    public interface IAzureStorageRepository
    {
        Task<string> UploadFile(IFormFile File,string AzureConnectionString,string Container);

        Task<bool> DeleteFile(string FileUrl, string AzureConnectionString, string Container);
        Task<BlobDTO> downloadFile(string FileUrl ,string AzureConnectionString, string Container);
        Task<bool> IsBlobExist(string BlobUrl, string AzureConnectionString, string Container);
       
        
       


    }
}
