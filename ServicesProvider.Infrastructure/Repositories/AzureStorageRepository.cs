using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using ServicesProvider.Core.DTOs.Shared;
using Microsoft.Extensions.Logging;

namespace ServicesProvider.Infrastructure.Repositories
{
    public class AzureStorageRepository : IAzureStorageRepository
    {
        private readonly ILogger<AzureStorageRepository> _logger;
   


        public AzureStorageRepository(ILogger<AzureStorageRepository> logger) 
        {
        _logger=logger;
        }

        public async Task<bool> DeleteFile(string FileUrl, string AzureConnectionString, string Container)
        {
            var container = new BlobContainerClient(AzureConnectionString, Container);
            string BlobName = FileUrl.Substring(FileUrl.IndexOf(Container) + Container.Length);
            var blob = container.GetBlobClient(BlobName);
            return await blob.DeleteIfExistsAsync();

        }

        public async Task<BlobDTO> downloadFile(string FileUrl, string AzureConnectionString, string Container)
        {
            _logger.LogWarning("=========>>> Downloading file from File URL: "+FileUrl);


            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(AzureConnectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(Container);


                string BlobName = FileUrl.Substring(FileUrl.IndexOf(Container) + Container.Length);
                _logger.LogWarning("=========>>> Blob Name: " + BlobName);

                BlobClient blobClient = containerClient.GetBlobClient(BlobName);
               
                BlobDownloadInfo blobDownloadInfo = await blobClient.DownloadAsync();
                Stream stream = blobDownloadInfo.Content;
                return new BlobDTO() { IsSuccess = true, ContentStream = stream, ContentType = blobDownloadInfo.Details.ContentType, Name = BlobName.Substring(BlobName.LastIndexOf("/") + 1), Uri = FileUrl };


            }
            catch (Exception ex)
            {
              return  new BlobDTO() { IsSuccess = false, Error="File Not exist against URL: " +FileUrl};


            }







        }


        public async Task<bool> IsBlobExist(string BlobUrl, string AzureConnectionString, string Container)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(AzureConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(Container);

            try
            {
                string BlobName = BlobUrl.Substring(BlobUrl.IndexOf(Container) + Container.Length);


                BlobClient blobClient = containerClient.GetBlobClient(BlobName);

                return await blobClient.ExistsAsync();
            }
            catch 
            {

              return  false;
            }
         
        }

        public async Task<string> UploadFile(IFormFile File, string AzureConnectionString, string Container)
        {
            try
            {
                var container = new BlobContainerClient(AzureConnectionString, Container);

                // every time checking could slow down the process
                //var createResponse = await container.CreateIfNotExistsAsync();
                //if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                //    await container.SetAccessPolicyAsync(PublicAccessType.Blob);

                var blob = container.GetBlobClient("/customfolder/" + Guid.NewGuid().ToString() + "-" + File.FileName);
                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                using (var fileStream = File.OpenReadStream())
                {
                    await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = File.ContentType });

                }

                return blob.Uri.ToString();
            }
            catch (Exception)
            {

                return null;
            }
           
           
        }
    }
}
