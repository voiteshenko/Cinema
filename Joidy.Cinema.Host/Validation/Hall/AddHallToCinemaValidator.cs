using Cinema.Common;
using Cinema.Dtos.Request.Hall;
using FluentValidation;

namespace Cinema.Host.Validation.Hall;

public class AddHallToCinemaValidator : AbstractValidator<AddHallToCinemaRequest>
{
    private readonly int[] _hallTechnologyType = { 0, 1, 2, 3 };
    private readonly int[] _hallType = { 0, 1, 2, 3 };

    public AddHallToCinemaValidator()
    {
        RuleFor(m => m.CinemaId).Must((m, c) => IsCinemaIdValid(m)).WithMessage(ErrorMessages.CinemaIdNotValid);
        RuleFor(m => m.Name).NotNull().NotEmpty().WithMessage(ErrorMessages.NameShouldNotBeEmpty);
        RuleFor(m => m.Boarding).NotNull().NotEmpty().WithMessage(ErrorMessages.BoardingShouldNotBeEmpty);
        RuleFor(m => m.Technology).Must((m, c) => IsHallTechnologyTypeValid(m)).WithMessage(ErrorMessages.InvalidHallTechnologyType);
        RuleFor(m => m.Type).Must((m, c) => IsHallTypeValid(m)).WithMessage(ErrorMessages.InvalidHallType);
        RuleFor(m => m.Rows).Must((m, c) => IsRowsValid(m)).WithMessage(ErrorMessages.InvalidHallRows);
    }

    private bool IsRowsValid(AddHallToCinemaRequest request)
    {
        return request.Rows != null && request.Rows.Any();
    }

    private bool IsHallTypeValid(AddHallToCinemaRequest request)
    {
        return _hallType.Any(t => t == (int)request.Type);
    }

    private bool IsHallTechnologyTypeValid(AddHallToCinemaRequest request)
    {
        return _hallTechnologyType.Any(t => t == (int)request.Technology);
    }

    private bool IsCinemaIdValid(AddHallToCinemaRequest request)
    {
        return request.CinemaId != Guid.Empty;
    }
}