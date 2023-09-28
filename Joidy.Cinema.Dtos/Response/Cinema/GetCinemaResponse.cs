namespace Cinema.Dtos.Response.Cinema;

public class GetCinemaResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public IEnumerable<GetHallResponse> Halls { get; set; }
}