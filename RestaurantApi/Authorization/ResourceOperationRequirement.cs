using Microsoft.AspNetCore.Authorization;
using RestaurantApi.Models.Enums;

namespace RestaurantApi.Authorization
{
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperation ResourceOperation { get; }
        public ResourceOperationRequirement(ResourceOperation resourceOperation) 
        {
            ResourceOperation = resourceOperation;
        }
    }
}
