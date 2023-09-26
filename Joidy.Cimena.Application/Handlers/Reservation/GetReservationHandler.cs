using Joidy.Cinema.Application.Queries;
using Joidy.Common.DataLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Joidy.Cinema.Application.Handlers.Reservation;

internal class GetReservationHandler : EntityService<DataLayer.Entities.Reservation>, IRequestHandler<GetReservationQuery, DataLayer.Entities.Reservation>
{
    public GetReservationHandler(IRepository<DataLayer.Entities.Reservation> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<DataLayer.Entities.Reservation> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var reservation = await Repository
            .Where(r => r.Id == request.id)
            .Include(r => r.ShowTime).ThenInclude(st => st.Movie)
            .Include(r => r.SeatReservations)
            .FirstAsync();

        return reservation;
    }
}