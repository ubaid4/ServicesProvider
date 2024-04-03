using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.CoreActivities;
using ServicesProvider.Core.DTOs.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.ServicInterfaces
{
    public interface ICoreActivityService
    {
        Task<BaseResponce> GetCoreActivity(string CoreActivityId);
        Task<BaseResponce> GetAllCoreActivities();

         Task<BaseResponce>  GetAllCoreActivitiesByCategory(string CategoryId);
        Task<BaseResponce> AddCoreActivity(CoreActivityAddDTO CoreActivity);
        Task<BaseResponce> DeleteCoreActivity(string CoreActivityId);
        Task<BaseResponce> UpdateCoreActivity(CoreActivityEditDTO CoreActivity);
    }
}
