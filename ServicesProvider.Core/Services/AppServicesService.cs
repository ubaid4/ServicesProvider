using AutoMapper;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Domain.RepositoryInterfaces;
using ServicesProvider.Core.DTOs.Services;
using ServicesProvider.Core.DTOs.Shared;
using ServicesProvider.Core.ServicInterfaces;

namespace ServicesProvider.Core.Services
{
    public class AppServicesService : IAppServicesService
    {
        private readonly IAppServicesRepository _appServiceRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICoreActivityRepository _coreActivityService;

        private readonly IMapper _mapper;

        public AppServicesService(IAppServicesRepository appServiceRepository,IMapper mapper, ICategoryRepository categoryRepository, ICoreActivityRepository coreActivityRepository) 
        {
            _appServiceRepository = appServiceRepository;
            _categoryRepository = categoryRepository;
            _coreActivityService = coreActivityRepository;
            _mapper = mapper;
        
        
        }
        public async Task<BaseResponce> AddAppService(ServiceAddDTO AppService)
        {
            Category category = await _categoryRepository.GetById(Guid.Parse( AppService.CategoryId));
            if (category == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Category not found against: "+ AppService.CategoryId, };
            }

            CoreActivity coreActivity = await _coreActivityService.GetById(Guid.Parse(AppService.CoreActivityId));
            if (coreActivity == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "CoreActivity not found against: "+AppService.CoreActivityId };
            }
            AppServices Service = _mapper.Map<AppServices>(AppService);
            //Service.Id = Guid.NewGuid();

            AppServices res = await _appServiceRepository.Add(Service);
            if (res == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Failed to add Service", };
            }
            return new GenericResponce { IsSuccess = true, Message = "Service added successfully", Data = _mapper.Map<ServiceResponceDTO>(res) };



        }

        public async Task<BaseResponce> DeleteAppService(string AppServiceId)
        {
            AppServices Service = await _appServiceRepository.GetById(Guid.Parse(AppServiceId));
            if (Service == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Service not found", };
            }

            Service = await _appServiceRepository.Delete(Service);
            if (Service == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Failed to delete Service", };
            }
            return new GenericResponce { IsSuccess = true, Message = "Service deleted successfully", Data = _mapper.Map<ServiceResponceDTO>(Service) };




        }

        public async Task<BaseResponce> GetAllAppServices()
        {
          IList<AppServices> services  =await _appServiceRepository.GetAll();
            if (services.Count == 0)
            {
                return new BaseResponce { IsSuccess = true, Message = "No Service found", };
            }
            return new GenericResponce { IsSuccess = true, Message = "Service found successfully", Data = _mapper.Map<List<ServiceResponceDTO>>(services) };
        }

        public async Task<BaseResponce> GetAllAppServicesByCategory(string CategoryId)
        {
            Category category = await _categoryRepository.GetById(Guid.Parse(CategoryId));
            if (category == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Category not found against: " + CategoryId, };
            }
            IList<AppServices> services = await _appServiceRepository.GetServicesByCategoryId(Guid.Parse(CategoryId));
            if (services.Count == 0)
            {
                return new BaseResponce { IsSuccess = true, Message = "No Service found", };
            }
            return new GenericResponce { IsSuccess = true, Message = "Service found successfully", Data = _mapper.Map<List<ServiceResponceDTO>>(services) };
        }

        public async Task<BaseResponce> GetAllAppServicesByCoreActivity(string CoreActivityId)
        {
            CoreActivity coreActivity = await _coreActivityService.GetById(Guid.Parse(CoreActivityId));
            if (coreActivity == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "CoreActivity not found against: " + CoreActivityId };
            }
            IList<AppServices> services = await _appServiceRepository.GetServicesByCoreActivity(Guid.Parse(CoreActivityId));
            if (services.Count == 0)
            {
                return new BaseResponce { IsSuccess = true, Message = "No Service found", };
            }
            return new GenericResponce { IsSuccess = true, Message = "Service found successfully", Data = _mapper.Map<List<ServiceResponceDTO>>(services) };
        }

        public async Task<BaseResponce> GetAppService(string AppServiceId)
        {
           AppServices services= await _appServiceRepository.GetById(Guid.Parse(AppServiceId));
            if (services == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Service not found", };
            }
            return new GenericResponce { IsSuccess = true, Message = "Service found successfully", Data = _mapper.Map<ServiceResponceDTO>(services) };
        }

        public async Task<BaseResponce> UpdateAppService(ServiceEditDTO AppService)
        {

            Category category = await _categoryRepository.GetById(Guid.Parse(AppService.CategoryId));
            if (category == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Category not found against: " + AppService.CategoryId, };
            }

            CoreActivity coreActivity = await _coreActivityService.GetById(Guid.Parse(AppService.CoreActivityId));
            if (coreActivity == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "CoreActivity not found against: " + AppService.CoreActivityId };
            }
            AppServices services= await _appServiceRepository.Update(_mapper.Map<AppServices>(AppService));
            if (services == null)
            {
                return new BaseResponce { IsSuccess = false, Message = "Failed to update Service", };
            }
            return new GenericResponce { IsSuccess = true, Message = "Service updated successfully", Data = _mapper.Map<ServiceResponceDTO>(services) };
        }
    }
}
