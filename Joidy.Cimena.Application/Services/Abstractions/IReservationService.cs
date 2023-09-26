namespace Joidy.Cinema.Application.Services.Abstractions;

public interface IReservationService
{
    Task RemoveUnapprovedReservation();
}