﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApi.Dtos;
using RestaurantApi.Dtos.Create;
using RestaurantApi.Dtos.Update;
using RestaurantApi.Entities;
using RestaurantApi.Services.Interfaces;

namespace RestaurantApi.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurants = _service.GetAll();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get([FromRoute] int id)
        {
            var restaurant = _service.Get(id);
            return Ok(restaurant);
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            var restaurant = _service.Create(dto);
            return Created($"api/restaurant/{restaurant.Id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateRestaurantDto dto)
        {
            _service.Update(id, dto);
            return Ok();
        }

    }
}