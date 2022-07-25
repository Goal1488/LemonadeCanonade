using FluentValidation;
using Lemonade.Api.ViewModels.Lemonade;

namespace Lemonade.Api.Validators;

public class LemonadeCreateViewModelValidator : AbstractValidator<LemonadeViewModel>
{
    public LemonadeCreateViewModelValidator()
    {
        RuleFor(model => model.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(model => model.Name)
            .MaximumLength(48)
            .WithMessage("Name field is too long, 48 characters max allowed");

        RuleFor(model => model.Name)
            .Matches(@"^[a-z](\/?[0-9a-z-])*\/?$")
            .WithMessage("Invalid Name field format. Should be [a-z0-9-]");
    }
}
public class LemonadeSizeCreateViewModelValidator : AbstractValidator<LemonadeSizeViewModel>
{
    public LemonadeSizeCreateViewModelValidator()
    {
        RuleFor(model => model.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price should be greater or equal than 0");
    }
}