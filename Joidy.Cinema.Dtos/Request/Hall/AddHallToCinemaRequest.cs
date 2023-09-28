using Cinema.Dtos.Request.Cinema;

namespace Cinema.Dtos.Request.Hall;

public class AddHallToCinemaRequest : AddHallRequest
{
    public Guid CinemaId { get; set; }
}