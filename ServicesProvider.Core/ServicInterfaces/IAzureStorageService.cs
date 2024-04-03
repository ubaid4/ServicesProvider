using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.ServicInterfaces
{
    public interface IAzureStorageService
    {
        Task<BaseResponce> UploadSingleFile(IFormFile File);
        Task<BaseResponce?> IsBloabExist(string Url);
        Task<BaseResponce> UploadMultipleFiles(List<IFormFile> Files);
        Task<BlobDTO> DownloadFile(string FileUrl);
        Task<BaseResponce> DeleteFile(string FileUrl);

       

 
    }
}
