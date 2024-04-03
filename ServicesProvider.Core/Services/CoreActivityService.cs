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

        public CoreActivityService(ICoreActivityRepository coreActivityRepository,  IMapper mapper,ICategoryRepository categoryRepository) 
        {
            _coreActivityRepository = coreActivityRepository;
            _categoryRepository = categoryRepository;
         
            _mapper = mapper;
        }
        public async Task<BaseResponce> AddCoreActivity(CoreActivityAddDTO CoreActivity)
        {         
            CoreActivity activity=_mapper.Map<CoreActivity>(CoreActivity);


            CoreActivity res= await _coreActivityRepository.Add(activity);
            if(res == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Failed to add CoreActivity",  };
            }
            return new GenericResponce { IsSuccess = true, Message = "CoreActivity added successfully",Data=_mapper.Map<CoreActivityResponceDTO>(res) };
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
            return new GenericResponce { IsSuccess = true, Message = "CoreActivity deleted successfully",Data=_mapper.Map<CoreActivityEditDTO>(activity)  };

            
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
            Category category = await _categoryRepository.GetById(Guid.Parse(CategoryId));
            if (category == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Category not found against: " + CategoryId, };
            }
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

        public async Task<BaseResponce> UpdateCoreActivity(CoreActivityEditDTO CoreActivity)
        {
            Category category = await _categoryRepository.GetById(Guid.Parse(CoreActivity.CategoryId));
            if (category == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Category not found against: " + CoreActivity.CategoryId, };
            }

            CoreActivity Activity= await _coreActivityRepository.Update(_mapper.Map<CoreActivity>(CoreActivity));
            if(CoreActivity==null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Failed to update CoreActivity",  };
            }
            return new GenericResponce { IsSuccess = true, Message = "CoreActivity updated successfully",Data=_mapper.Map<CoreActivityEditDTO>(Activity)  };

        }
    }
}
