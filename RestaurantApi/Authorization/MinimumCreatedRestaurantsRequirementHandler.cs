using Microsoft.AspNetCore.Authorization;
using RestaurantApi.Entities;
using System.Security.Claims;

namespace RestaurantApi.Authorization
{
    public class MinimumCreatedRestaurantsRequirementHandler : AuthorizationHandler<MinimunCreatedRestaurantsRequirement>
    {
        private readonly RestaurantDbContext _dbContext;

        public MinimumCreatedRestaurantsRequirementHandler(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimunCreatedRestaurantsRequirement requirement)
        {
            var authorizeUserId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var numberOfCreatedRestaurantsByUser = _dbContext.Restaurants.Count(r => r.CreatedById == authorizeUserId);

            if(numberOfCreatedRestaurantsByUser >= requirement.MinimumNumberOfCreatedRestaurant) 
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
