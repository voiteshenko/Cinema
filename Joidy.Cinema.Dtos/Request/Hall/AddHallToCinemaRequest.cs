using Joidy.Cinema.Dtos.Request.Cinema;

namespace Joidy.Cinema.Dtos.Request.Hall;

public class AddHallToCinemaRequest : AddHallRequest
{
    public Guid CinemaId { get; set; }
}