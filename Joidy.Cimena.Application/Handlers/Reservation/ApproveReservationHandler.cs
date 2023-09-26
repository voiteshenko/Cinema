using Joidy.Cinema.Application.Commands.Reservation;
using Joidy.Cinema.Common;
using Joidy.Common.DataLayer;
using Joidy.Common.Functional.Option;
using MediatR;
using static Joidy.Common.Functional.Option.OptionStatic;

namespace Joidy.Cinema.Application.Handlers.Reservation;

public class ApproveReservationHandler : EntityService<DataLayer.Entities.Reservation>, IRequestHandler<ApproveReservationCommand, Option<string>>
{
    public ApproveReservationHandler(IRepository<DataLayer.Entities.Reservation> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Option<string>> Handle(ApproveReservationCommand command, CancellationToken cancellationToken)
    {
        var reservation = await FindAsync(new object[] { command.Request.ReservationId });

        if (reservation == null)
        {
            return Some(ErrorMessages.ReservationNotFound);
        }

        reservation.IsApproved = true;

        await UpdateAsync(reservation);

        return None<string>();
    }
}