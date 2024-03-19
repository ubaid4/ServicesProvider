using AutoMapper;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.DTOs.Categories;
using ServicesProvider.Core.DTOs.CoreActivities;
using ServicesProvider.Core.DTOs.Roles;
using ServicesProvider.Core.DTOs.Users;

namespace ServicesProvider.UI
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AppUser, UserDTO>();

            //you can use .ForMember to map the properties with different names
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest=>dest.OrderNumber,opt=>opt.MapFrom(src=>src.RenderOrder))
                .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.Name));

            CreateMap<CategoryDTO, Category>()
                .ForMember(dest=>dest.RenderOrder,opt=>opt.MapFrom(src=>src.OrderNumber))
                .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.EnglishName));

            CreateMap<CoreActivityDTO, CoreActivity>()
                .ForMember(dest => dest.RenderOrder, opt => opt.MapFrom(src => src.OrderNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnglishName));

            CreateMap<CoreActivity, CoreActivityDTO>()
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.RenderOrder))
                .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.Name));

            CreateMap<AppRole, RoleDTO>();
            CreateMap<RoleDTO, AppRole>();

            CreateMap<CoreActivity, CoreActivityResponceDTO>()
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.RenderOrder))
                .ForMember(dest => dest.EnglishName, opt => opt.MapFrom(src => src.Name));


            CreateMap<Category, CategoryResponceDTO>();

        }
    }
}
