namespace Cinema.Dtos.Request.ShowTime;

public class AddShowTimeRequest
{
    public Guid MovieId { get; set; }

    public Guid HallId { get; set; }

    public DateTime StartDate { get; set; }
}