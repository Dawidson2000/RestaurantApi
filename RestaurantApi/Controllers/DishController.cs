using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Dtos;
using RestaurantApi.Dtos.Create;
using RestaurantApi.Services.Interfaces;

namespace RestaurantApi.Controllers
{
    [Route("api/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        public readonly IDishService _service;
        public DishController(IDishService service)
        {
            _service = service;
        }
        [HttpPost]
        public ActionResult Create([FromRoute] int restaurantId, CreateDishDto dto)
        {
            var dishId = _service.Create(restaurantId, dto);
            return Created($"api/{restaurantId}/dish/{dishId}", null);
        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute]int restaurantId, [FromRoute]int dishId) 
        {
            var dishDto = _service.Get(restaurantId, dishId);
            return Ok(dishDto);
        }

        [HttpGet]
        public ActionResult<List<DishDto>> GetAll([FromRoute] int restaurantId)
        {
            var dishesDto = _service.GetAll(restaurantId);
            return Ok(dishesDto);
        }

        [HttpDelete("{dishId}")]
        public ActionResult Delete([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            _service.Delete(restaurantId, dishId);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteAll([FromRoute]int restaurantId)
        {
            _service.DeleteAll(restaurantId);
            return NoContent();
        }
    }
}
