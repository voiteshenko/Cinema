using FluentValidation;
using Joidy.Cinema.Common;
using Joidy.Cinema.Dtos.Request.ShowTime;

namespace Joidy.Cinema.Host.Validation.ShowTime;

public class AddShowTimeValidator : AbstractValidator<AddShowTimeRequest>
{
    public AddShowTimeValidator()
    {
        RuleFor(m => m.StartDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage(ErrorMessages.InvalidValueForStartDate);
        RuleFor(m => m.HallId).Must((m, c) => IsHallIdValid(m)).WithMessage(ErrorMessages.InvalidValueForHallId);
        RuleFor(m => m.MovieId).Must((m, c) => IsMovieIsValid(m)).WithMessage(ErrorMessages.InvalidMovieId);
    }

    private bool IsHallIdValid(AddShowTimeRequest request)
    {
        return request.HallId != Guid.Empty;
    }

    private bool IsMovieIsValid(AddShowTimeRequest request)
    {
        return request.MovieId != Guid.Empty;
    }
}