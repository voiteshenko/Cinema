using Cinema.Application.Services.Abstractions;
using Common.Hangfire;

namespace Cinema.Host.Jobs;

public class RemoveUnapprovedReservationJob : RecurringJobBase
{
    private readonly IReservationService _reservationService;

    public RemoveUnapprovedReservationJob(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    public override async Task Run(CancellationToken cancellationToken = default)
    {
        await _reservationService.RemoveUnapprovedReservation();
    }
}