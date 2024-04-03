using AutoMapper;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.CoreActivities;
using ServicesProvider.Core.DTOs.Roles;
using ServicesProvider.Core.DTOs.Services;
using ServicesProvider.Core.DTOs.Users;

namespace ServicesProvider.UI
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, UserDTO>();

            //you can use .ForMember to map the properties with different names
            CreateMap<Category, EditCategoryDTO>()
                .ForMember(dest=>dest.OrderNumber,opt=>opt.MapFrom(src=>src.RenderOrder))
                .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<EditCategoryDTO, Category>()
                .ForMember(dest => dest.RenderOrder, opt => opt.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnglishName))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.IconUrl));



            CreateMap<Category, AddCategoryDTO>()
               .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.RenderOrder))
               .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<AddCategoryDTO, Category>()
                .ForMember(dest => dest.RenderOrder, opt => opt.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnglishName))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.IconUrl));


            CreateMap<CoreActivityAddDTO, CoreActivity>()
                .ForMember(dest => dest.RenderOrder, opt => opt.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnglishName))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.IconUrl));




            CreateMap<CoreActivityEditDTO, CoreActivity>()
                .ForMember(dest => dest.RenderOrder, opt => opt.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnglishName))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.IconUrl));


            CreateMap<CoreActivity, CoreActivityEditDTO>()
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.RenderOrder))
                .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.ImageUrl));


        
            CreateMap<ServiceAddDTO, AppServices>()
       .ForMember(dest => dest.RenderOrder, opt => opt.MapFrom(src => src.OrderNumber))
       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnglishName))
       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.EnglishDescription))
       .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.IconUrl));


            CreateMap<ServiceEditDTO, AppServices>()
                       .ForMember(dest => dest.RenderOrder, opt => opt.MapFrom(src => src.OrderNumber))
       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnglishName))
       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.EnglishDescription))
       .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.IconUrl));

            CreateMap<AppServices, ServiceResponceDTO>()
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.RenderOrder))
                .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.EnglishDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.ImageUrl));





            CreateMap<CoreActivity, CoreActivityResponceDTO>()
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.RenderOrder))
                .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IconURL, opt => opt.MapFrom(src => src.ImageUrl));

            



            CreateMap<AppRole, RoleDTO>();
            CreateMap<RoleDTO, AppRole>();

  


            CreateMap<Category, CategoryWithChildResponceDTO>()
                .ForMember(dest => dest.IconURL, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<Category, CategoryResponceDTO>()
                .ForMember(dest => dest.IconURL, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.RenderOrder));
            


        }
    }
}
