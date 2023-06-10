using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Dtos;
using RestaurantApi.Dtos.Create;
using RestaurantApi.Dtos.Update;
using RestaurantApi.Entities;
using RestaurantApi.Models.Queries;
using System.Security.Claims;

namespace RestaurantApi.Services.Interfaces
{
    public interface IRestaurantService
    {
        public RestaurantDto Get(int id);
        public PagedResult<RestaurantDto> GetAll(RestaurantQuery query);
        public Restaurant Create(CreateRestaurantDto dto);
        public void Update(int id, UpdateRestaurantDto dto);
        public void Delete(int id);
    }
}
