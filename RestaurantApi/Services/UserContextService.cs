using RestaurantApi.Services.Interfaces;
using System.Security.Claims;

namespace RestaurantApi.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public UserContextService(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }

        public ClaimsPrincipal User => _httpcontextAccessor.HttpContext?.User;
        public int? GetUserId => User is null ? null : (int?)int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
    }
}
