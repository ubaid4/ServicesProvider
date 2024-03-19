using AutoMapper;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.DTOs.CoreActivities;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.ServicInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Core.Services
{
    public class CoreActivityService : ICoreActivityService
    {
        private readonly ICoreActivityRepository _coreActivityRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CoreActivityService(ICoreActivityRepository coreActivityRepository, ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _coreActivityRepository = coreActivityRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponce> AddCoreActivity(CoreActivityDTO CoreActivity)
        {
            Category category = await _categoryRepository.GetById(new Guid(CoreActivity.CategoryId));


            CoreActivity.Id= Guid.NewGuid().ToString();
            CoreActivity activity=_mapper.Map<CoreActivity>(CoreActivity);
           // activity.Category = category;
            CoreActivity res= await _coreActivityRepository.Add(activity);
            if(res == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Failed to add CoreActivity",  };
            }
            return new GenericResponce { IsSuccess = true, Message = "CoreActivity added successfully",Data=_mapper.Map<CoreActivityDTO>(res) };
        }

        public async Task<BaseResponce> DeleteCoreActivity(string CoreActivityId)
        {
            CoreActivity activity =await _coreActivityRepository.GetById(Guid.Parse(CoreActivityId));   
            if(activity==null)
            {
                return new BaseResponce { IsSuccess = false, Message = "CoreActivity not found",  };
            }

            activity=await _coreActivityRepository.Delete(activity);
            if(activity==null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Failed to delete CoreActivity",  };
            }
            return new GenericResponce { IsSuccess = true, Message = "CoreActivity deleted successfully",Data=_mapper.Map<CoreActivityDTO>(activity)  };

            
        }

        public async Task<BaseResponce> GetAllCoreActivities()
        {
            
            IList<CoreActivity> coreActivities=await _coreActivityRepository.GetAll();
            if(coreActivities.Count==0)
            {
                return new BaseResponce { IsSuccess = true, Message = "No CoreActivity found",  };
            }
            return new GenericResponce { IsSuccess = true, Message = "CoreActivities found successfully",Data=coreActivities.Select(x=>_mapper.Map<CoreActivityResponceDTO>(x)) };

        }

        public async Task<BaseResponce> GetAllCoreActivitiesByCategory(string CategoryId)
        {
           IList<CoreActivity> coreActivities  =await _coreActivityRepository.GetCoreActivitiesByCategoryId(Guid.Parse(CategoryId));
            if (coreActivities.Count == 0)
            {
                return new BaseResponce { IsSuccess = true, Message = "No CoreActivity found", };
            }
            return new GenericResponce { IsSuccess = true, Message = "CoreActivities found successfully", Data = coreActivities.Select(x => _mapper.Map<CoreActivityResponceDTO>(x)) };
           
        }

        public async Task<BaseResponce> GetCoreActivity(string CoreActivityId)
        {
            CoreActivity activity = await _coreActivityRepository.GetById(Guid.Parse(CoreActivityId));
            if (activity == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "CoreActivity not found", };
            }
            return new GenericResponce { IsSuccess = true, Message = "CoreActivity found successfully", Data = _mapper.Map<CoreActivityResponceDTO>(activity) };

        }

        public async Task<BaseResponce> UpdateCoreActivity(CoreActivityDTO CoreActivity)
        {
            
            CoreActivity Activity= await _coreActivityRepository.Update(_mapper.Map<CoreActivity>(CoreActivity));
            if(CoreActivity==null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Failed to update CoreActivity",  };
            }
            return new GenericResponce { IsSuccess = true, Message = "CoreActivity updated successfully",Data=_mapper.Map<CoreActivityDTO>(Activity)  };

        }
    }
}
