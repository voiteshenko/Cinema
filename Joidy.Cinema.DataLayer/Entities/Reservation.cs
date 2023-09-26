namespace Joidy.Cinema.DataLayer.Entities;

public class Reservation
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public bool IsApproved { get; set; }

    public ShowTime ShowTime { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreationDate { get; set; }

    public ICollection<SeatReservation> SeatReservations { get; set; }
}