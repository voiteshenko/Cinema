namespace Cinema.Application.Services.Abstractions;

public interface IReservationService
{
    Task RemoveUnapprovedReservation();
}