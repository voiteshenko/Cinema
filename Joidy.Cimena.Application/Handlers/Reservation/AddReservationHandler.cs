using Joidy.Cinema.Application.Commands.Reservation;
using Joidy.Cinema.Common;
using Joidy.Cinema.DataLayer.Entities;
using Joidy.Common.DataLayer;
using Joidy.Common.Functional.Option;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Joidy.Common.Functional.Option.OptionStatic;

namespace Joidy.Cinema.Application.Handlers.Reservation;

public class AddReservationHandler : EntityService<DataLayer.Entities.Reservation>, IRequestHandler<AddReservationCommand, Option<string>>
{
    private readonly IRepository<DataLayer.Entities.ShowTime> _showTimeRepository;
    private readonly IRepository<SeatReservation> _seatReservationRepository;
    private readonly IRepository<Row> _rowRepository;

    public AddReservationHandler(
        IRepository<DataLayer.Entities.Reservation> repository,
        IUnitOfWork unitOfWork,
        IRepository<DataLayer.Entities.ShowTime> showTimeRepository,
        IRepository<SeatReservation> seatReservationRepository,
        IRepository<Row> rowRepository) : base(repository, unitOfWork)
    {
        _showTimeRepository = showTimeRepository;
        _seatReservationRepository = seatReservationRepository;
        _rowRepository = rowRepository;
    }

    public async Task<Option<string>> Handle(AddReservationCommand command, CancellationToken cancellationToken)
    {
        var showTime = await _showTimeRepository
            .Include(st => st.Hall)
            .ThenInclude(h => h.Rows)
            .FirstOrDefaultAsync(st => st.Id == command.Request.ShowTimeId);

        if (showTime == null)
        {
            return Some(ErrorMessages.ShowTimeNotFound);
        }

        var showTimeSeatReservation = await _seatReservationRepository
            .Where(sr => sr.Reservation.ShowTime.Id == command.Request.ShowTimeId)
            .Include(sr => sr.Reservation)
            .ThenInclude(r => r.ShowTime)
            .ToListAsync();

        if (command.Request.SeatReservations
            .Any(seatReservation => showTimeSeatReservation
                .Any(stsr => stsr.RowNumber == seatReservation.RowNumber && stsr.SeatNumber == seatReservation.SeatNumber)))
        {
            return Some(ErrorMessages.ReservationAlreadyExist);
        }

        var totalPrice = command.Request.SeatReservations
            .Select(seatReservation => showTime.Hall.Rows.First(r => r.Number == seatReservation.RowNumber).Price)
            .Aggregate<decimal, decimal>(0, (current, priceOfOne) => current + priceOfOne);

        await CreateAsync(new DataLayer.Entities.Reservation
        {
            Id = Guid.NewGuid(),
            ShowTime = showTime,
            TotalPrice = totalPrice,
            Email = command.Request.Email,
            IsApproved = false,
            CreationDate = DateTime.Now,
            SeatReservations = command.Request.SeatReservations.Select(sr => new SeatReservation
            {
                Id = Guid.NewGuid(),
                RowNumber = sr.RowNumber,
                SeatNumber = sr.SeatNumber
            }).ToList()
        });

        return None<string>();
    }
}