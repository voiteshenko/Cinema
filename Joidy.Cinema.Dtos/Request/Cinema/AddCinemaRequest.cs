namespace Cinema.Dtos.Request.Cinema;

public class AddCinemaRequest
{
    public string? Name { get; set; }

    public string? Address { get; set; }

    public IEnumerable<AddHallRequest>? Halls { get; set; }
}