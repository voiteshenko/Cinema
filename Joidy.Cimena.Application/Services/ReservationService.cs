using Cinema.Application.Services.Abstractions;
using Cinema.DataLayer.Entities;
using Common.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Services;

public class ReservationService : EntityService<Reservation>, IReservationService
{
    public ReservationService(IRepository<Reservation> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
    public async Task RemoveUnapprovedReservation()
    {
        var reservations = await Repository.Where(r => !r.IsApproved).ToListAsync();

        var reservationToRemove = reservations.Where(r => DateTime.Now.Subtract(r.CreationDate).Minutes >= 30).ToList();

        if (reservationToRemove.Any())
        {
            await DeleteManyAsync(reservationToRemove);
        }
    }
}