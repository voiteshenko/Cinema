namespace Cinema.Dtos.Response.Reservation;

public class GetReservationResponse
{
    public Guid Id { get; set; }

    public string Movie { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public decimal TotalPrice { get; set; }

    public bool IsApproved { get; set; }

    public string Email { get; set; }

    public IEnumerable<GetSeatReservationResponse> SeatReservations { get; set; }
}