using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Dtos;
using RestaurantApi.Dtos.Create;
using RestaurantApi.Dtos.Update;
using RestaurantApi.Entities;
using System.Security.Claims;

namespace RestaurantApi.Services.Interfaces
{
    public interface IRestaurantService
    {
        public RestaurantDto Get(int id);
        public IEnumerable<RestaurantDto> GetAll();
        public Restaurant Create(CreateRestaurantDto dto);
        public void Update(int id, UpdateRestaurantDto dto);
        public void Delete(int id);
    }
}
