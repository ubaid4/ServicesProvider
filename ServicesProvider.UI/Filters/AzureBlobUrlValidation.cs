using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.ServicInterfaces;
using System.Reflection;
using System.Text;

namespace ServicesProvider.UI.Filters
{
    public class AzureBlobUrlValidation :IAsyncActionFilter
    {
        private readonly IAzureStorageService _azureStorageService;
        public AzureBlobUrlValidation(IAzureStorageService azureStorageService)
        {
            _azureStorageService = azureStorageService;
            
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {


            var ActionDto = context.ActionArguments.FirstOrDefault().Value;
            //this is the way parse request body to specific static model
            //AddCategoryDTO category = (AddCategoryDTO)ActionDto;
            //we need a generic way to get property value from object
            var Url =GetPropertyValue(ActionDto, "IconUrl");
            if (Url != null)
            {
                BaseResponce res = await _azureStorageService.IsBloabExist(Url.ToString());
                if (!res.IsSuccess)
                {
                    context.Result = new BadRequestObjectResult(new BaseResponce() { IsSuccess = false, Message = "Invalid Icon URL", Errors = new List<string> { "Attached Url file is not exist in our domain, Please Upload file with storage module then attach corresponding URL with request." } }); ;
                    return;
                }

            }
           

            //get file from azure blob storage
            //check if file exists

            await next();
        }
        public static object GetPropertyValue(object obj, string propertyName)
        {
            // Get the type of the object
            Type type = obj.GetType();

            // Get the property with the specified name
            PropertyInfo property = type.GetProperty(propertyName);


            if (property != null)
            {
                // Get the value of the property
                return property.GetValue(obj);
            }
            else
            {
                return null;
            }
        }

    }
}
