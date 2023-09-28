using Cinema.Common;
using Cinema.Dtos.Request.Reservation;
using FluentValidation;

namespace Cinema.Host.Validation.Reservation;

public class ApproveReservationValidator : AbstractValidator<ApproveReservationRequest>
{
    public ApproveReservationValidator()
    {
        RuleFor(m => m.ReservationId).Must((m, c) => IsReservationIdValid(m)).WithMessage(ErrorMessages.InvalidValueForReservationId);
    }

    private bool IsReservationIdValid(ApproveReservationRequest request)
    {
        return request.ReservationId != Guid.Empty;
    }
}