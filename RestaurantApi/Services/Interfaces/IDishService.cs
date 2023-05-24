using RestaurantApi.Dtos;
using RestaurantApi.Dtos.Create;

namespace RestaurantApi.Services.Interfaces
{
    public interface IDishService
    {
        public int Create(int restaurantId, CreateDishDto dto);
        public DishDto Get(int restaurantId, int dishId);
        public List<DishDto> GetAll(int restaurantId);
        public void Delete(int restaurantId, int DishId);
        public void DeleteAll(int restaurantId);
    }
}
