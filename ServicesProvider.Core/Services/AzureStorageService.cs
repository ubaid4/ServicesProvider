using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.ServicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly IAzureStorageRepository _azureStorageRepository;
        private readonly string? ConnectionString;
        private readonly string? Container;
        public AzureStorageService(IAzureStorageRepository azureStorageRepository, IConfiguration configuration) 
        {
            _azureStorageRepository=azureStorageRepository;
        
            ConnectionString=configuration.GetRequiredSection("AzureStorage:ConnectionString").Value;
            Container=configuration.GetRequiredSection("AzureStorage:ContainerName").Value;
        }

        public async Task<BaseResponce> DeleteFile(string FileUrl)
        {
            //Check if file exists
            BaseResponce res = await IsBloabExist(FileUrl);
            if (!res.IsSuccess)
            {
                return new BaseResponce() { IsSuccess = false, Message="File not found." ,Errors = new List<string> { "File Not exist against URL: " + FileUrl } };
            }
            bool isDeleted=await _azureStorageRepository.DeleteFile(FileUrl,ConnectionString,Container);
            if (!isDeleted)
            {
                return new BaseResponce() { IsSuccess = false, Message = "Unable to delete the file: "+FileUrl };
            }
            return new BaseResponce() { IsSuccess = true, Message = "File deleted successfully" };
            
        }

        public async Task<BlobDTO> DownloadFile(string FileUrl)
        {
            //Check if file exists
            BaseResponce res=await IsBloabExist(FileUrl);
            if (!res.IsSuccess)
            {
                return new BlobDTO() { IsSuccess = false, Error = "File Not exist against URL: " + FileUrl };
            }
         

            return await _azureStorageRepository.downloadFile(FileUrl,ConnectionString,Container);
 
        }

        public async Task<BaseResponce?> IsBloabExist(string Url)
        {
           bool IsExists = await _azureStorageRepository.IsBlobExist(Url, ConnectionString, Container);
            if (!IsExists)
            {
                return new BaseResponce() { IsSuccess = false, Message = "File doesn't exists" };
            }
            return new BaseResponce() { IsSuccess = true, Message = " Yes, file exists." };
        }

        public Task<BaseResponce> UploadMultipleFiles(List<IFormFile> Files)
        {
            throw new NotImplementedException();
        }




        public async Task<BaseResponce> UploadSingleFile(IFormFile File)
        {
            string Url= await _azureStorageRepository.UploadFile(File, ConnectionString, Container);
            if (string.IsNullOrEmpty(Url))
            {
                return new BaseResponce() { IsSuccess = false, Message = "Failed to upload file" };
            }
            return new GenericResponce() { IsSuccess = true, Message = "File uploaded successfully", Data = new { FileUrl = Url } };

        }
    }
}
