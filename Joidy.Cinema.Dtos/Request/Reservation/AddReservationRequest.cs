namespace Joidy.Cinema.Dtos.Request.Reservation;

public class AddReservationRequest
{
    public Guid ShowTimeId { get; set; }

    public string? Email { get; set; }

    public IEnumerable<AddSeatReservationRequest>? SeatReservations { get; set; }
}