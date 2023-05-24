using AutoMapper;
using RestaurantApi.Dtos;
using RestaurantApi.Dtos.Create;
using RestaurantApi.Entities;

namespace RestaurantApi.Mapping
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(x => x.City, y => y.MapFrom(z => z.Address.City))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Address.Street))
                .ForMember(x => x.PostalCode, y => y.MapFrom(z => z.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(x => x.Address, y => y.MapFrom(z => new Address() 
                {
                    City = z.City,
                    Street = z.Street,
                    PostalCode = z.PostalCode,
                }));

            CreateMap<CreateDishDto, Dish>();
        }

    }
}
