using FluentValidation;
using RestaurantApi.Entities;
using RestaurantApi.Models.Queries;
using System.Linq;

namespace RestaurantApi.Models.Validators
{
    public class RestaurantQueryValidator : AbstractValidator<RestaurantQuery>
    {
        private int[] allowedPageSize = new int[] {5, 10, 15};
        private string[] allowedSortColumns = new string[] 
            {nameof(Restaurant.Name), nameof(Restaurant.Description), nameof(Restaurant.Category) };
        
        public RestaurantQueryValidator() 
        {
            RuleFor(x => x.pageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.pageSize)
                .Custom((value, context) =>
                {
                    if (!allowedPageSize.Contains(value))
                    {
                        context.AddFailure("PageSize", $"PageSize must in [{string.Join(", ", allowedPageSize)}]");
                    }
                });
            RuleFor(x => x.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortColumns.Contains(value))
                .WithMessage($"Sort by is optional or must be in [{string.Join(", ", allowedSortColumns)}]");
        }
    }
}
