using System.Security.Claims;

namespace RestaurantApi.Services.Interfaces
{
    public interface IUserContextService
    {
        public ClaimsPrincipal User { get; }
        public int? GetUserId { get; }
    }
}
