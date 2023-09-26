using FluentValidation;
using Joidy.Cinema.Common;
using Joidy.Cinema.Dtos.Request.Cinema;

namespace Joidy.Cinema.Host.Validation.Cinema;

public class AddCinemaValidator : AbstractValidator<AddCinemaRequest>
{
    public AddCinemaValidator()
    {
        RuleFor(m => m.Name).NotNull().NotEmpty().WithMessage(ErrorMessages.NameShouldNotBeEmpty);
        RuleFor(m => m.Address).NotNull().NotEmpty().WithMessage(ErrorMessages.AddressShouldNotBeEmpty);
        RuleFor(m => m.Halls).NotEmpty().WithMessage(ErrorMessages.HallsShouldNotBeEmpty);
    }
}