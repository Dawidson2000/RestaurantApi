using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Dtos;
using RestaurantApi.Dtos.Create;
using RestaurantApi.Services.Interfaces;

namespace RestaurantApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) 
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]CreateUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
        
        [HttpPost("login")]
        public ActionResult LoginUser([FromBody]LoginDto loginDto) 
        {
            string token = _accountService.GenerateJwt(loginDto);
            return Ok(token);
        }
    }
} 
