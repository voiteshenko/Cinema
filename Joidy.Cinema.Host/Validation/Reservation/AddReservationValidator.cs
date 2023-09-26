using FluentValidation;
using Joidy.Cinema.Dtos.Request.Reservation;
using System.Text.RegularExpressions;
using Joidy.Cinema.Common;
using Z.Expressions;

namespace Joidy.Cinema.Host.Validation.Reservation;

public class AddReservationValidator : AbstractValidator<AddReservationRequest>
{
    public AddReservationValidator()
    {
        RuleFor(m => m.Email).Must((m, c) => IsEmailValid(m)).WithMessage(ErrorMessages.InvalidMailValue);
        RuleFor(m => m.ShowTimeId).Must((m, c) => IsShowTimeIdVqalid(m)).WithMessage(ErrorMessages.InvalidValueForShowTimeId);
        RuleFor(m => m.SeatReservations).NotEmpty().WithMessage(ErrorMessages.SeatReservationsShouldNotBeEmpty);
    }

    private bool IsShowTimeIdVqalid(AddReservationRequest request)
    {
        return request.ShowTimeId != Guid.Empty;
    }

    private bool IsEmailValid(AddReservationRequest request)
    {
        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        if (request.Email != null)
        {
            var match = regex.Match(request.Email);
            if (match.Success)
            {
                return true;
            }
        }

        return false;
    }
}