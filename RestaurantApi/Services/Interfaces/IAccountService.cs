using RestaurantApi.Dtos;
using RestaurantApi.Dtos.Create;
using RestaurantApi.Entities;

namespace RestaurantApi.Services.Interfaces
{
    public interface IAccountService
    {
        public void RegisterUser(CreateUserDto dto);
        public string GenerateJwt(LoginDto dto);
    }
}
