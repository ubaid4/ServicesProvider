using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.Enums;
using ServicesProvider.Core.ServicInterfaces;
using ServicesProvider.UI.Authorization.Attributes;

namespace ServicesProvider.UI.Controllers
{

    /// <summary>
    /// This controller is used to upload, download and delete files from Azure Blob Storage
    /// </summary>
    public class FileStorageController :BaseController
    {
        private readonly IAzureStorageService _azureStorageService;
        private readonly ILogger<FileStorageController> _logger;
        public FileStorageController(IAzureStorageService azureStorageService, ILogger<FileStorageController> logger)
        {
            _azureStorageService = azureStorageService;
            _logger = logger;
        }

        /// <summary>
        /// this endpoint is used to upload any type of file to Azure Blob Storage
        /// </summary>
        [AppPermission(AppModules.AzureStorage, ModuleAction.Add)]
        
        [HttpPost("UploadNew")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest(new BaseResponce() { IsSuccess = false, Message = "File is required" });
            }
            BaseResponce res = await _azureStorageService.UploadSingleFile(file);
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
          
            return Ok(res);
        }

        //the * before the parameter name is used to capture the whole URL
        [AppPermission(AppModules.AzureStorage, ModuleAction.Delete)]
        [HttpDelete("Delete/{*fileUrl:required}")]
        public async Task<IActionResult> DeleteFile(string fileUrl)
        {
            BaseResponce res = await _azureStorageService.DeleteFile(Uri.UnescapeDataString(fileUrl));
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
        [AppPermission(AppModules.AzureStorage, ModuleAction.View)]
        [HttpGet("IsExist/{*fileUrl:required}")]
        public async Task<IActionResult> IsBlobExist(string fileUrl)
        {
            BaseResponce res = await _azureStorageService.IsBloabExist(Uri.UnescapeDataString(fileUrl));
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [AppPermission(AppModules.AzureStorage, ModuleAction.View)]
        [HttpGet("Download/{*fileUrl:required}")]

        public async Task<IActionResult> DownloadFile(string fileUrl)
        {
   
            BlobDTO res = await _azureStorageService.DownloadFile(Uri.UnescapeDataString(fileUrl));
            if (!res.IsSuccess)
            {
                return BadRequest(res);
            }
            return File(res.ContentStream, res.ContentType, res.Name);
        }

   
    }
}
