using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Infrastructure.Repositories
{
    public class AzureStorageRepository : IAzureStorageRepository
    {



        public AzureStorageRepository() { }
        public async Task<string> UploadFile(IFormFile File, string AzureConnectionStrin, string AzureConnectionString)
        {
            try
            {
                var container = new BlobContainerClient(AzureConnectionStrin, AzureConnectionString);
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
