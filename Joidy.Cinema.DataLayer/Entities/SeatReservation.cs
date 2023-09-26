namespace Joidy.Cinema.DataLayer.Entities;

public class SeatReservation
{
    public Guid Id { get; set; }

    public int SeatNumber { get; set; }

    public int RowNumber { get; set; }

    public Reservation Reservation { get; set; }
}