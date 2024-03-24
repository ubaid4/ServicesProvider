using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.ServicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
     

        public async Task<string> UploadSingleFile(IFormFile File)
        {
            return await _azureStorageRepository.UploadFile(File, ConnectionString, Container);
            
        }
    }
}
