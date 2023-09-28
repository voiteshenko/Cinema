using Cinema.Common;
using Cinema.Dtos.Request.Cinema;
using FluentValidation;

namespace Cinema.Host.Validation.Cinema;

public class AddCinemaValidator : AbstractValidator<AddCinemaRequest>
{
    public AddCinemaValidator()
    {
        RuleFor(m => m.Name).NotNull().NotEmpty().WithMessage(ErrorMessages.NameShouldNotBeEmpty);
        RuleFor(m => m.Address).NotNull().NotEmpty().WithMessage(ErrorMessages.AddressShouldNotBeEmpty);
        RuleFor(m => m.Halls).NotEmpty().WithMessage(ErrorMessages.HallsShouldNotBeEmpty);
    }
}