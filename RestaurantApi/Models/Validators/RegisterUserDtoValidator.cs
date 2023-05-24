using FluentValidation;
using RestaurantApi.Dtos.Create;
using RestaurantApi.Entities;

namespace RestaurantApi.Models.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator(RestaurantDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailExist = dbContext.Users.Any(u => u.Email == value);
                    if (emailExist)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
