using ServicesProvider.Core.DTOs.CoreActivities;
using ServicesProvider.Core.DTOs.Services;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.ServicInterfaces
{
    public interface IAppServicesService
    {
        Task<BaseResponce> GetAppService(string AppServiceId);
        Task<BaseResponce> GetAllAppServices();

        Task<BaseResponce> GetAllAppServicesByCategory(string CategoryId);
        Task<BaseResponce> GetAllAppServicesByCoreActivity(string CoreActivityId);


        Task<BaseResponce> AddAppService(ServiceAddDTO AppService);
        Task<BaseResponce> DeleteAppService(string AppServiceId);
        Task<BaseResponce> UpdateAppService(ServiceEditDTO AppService);

    }
}
