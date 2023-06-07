using Microsoft.AspNetCore.Authorization;

namespace RestaurantApi.Authorization
{
    public class MinimunCreatedRestaurantsRequirement : IAuthorizationRequirement
    {
        public int MinimumNumberOfCreatedRestaurant {get;}

        public MinimunCreatedRestaurantsRequirement(int minimumNumberOfCreatedRestaurant)
        {
            MinimumNumberOfCreatedRestaurant = minimumNumberOfCreatedRestaurant;
        }
    }
}
