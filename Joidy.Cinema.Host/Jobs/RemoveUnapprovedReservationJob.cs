using Joidy.Cinema.Application.Services.Abstractions;
using Joidy.Common.Hangfire;

namespace Joidy.Cinema.Host.Jobs;

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