namespace Joidy.Cinema.Dtos.Response.ShowTime;

public class GetShowTimeResponse
{
    public Guid Id { get; set; }

    public string MovieName { get; set; }

    public string MovieDescription { get; set; }

    public string HallName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}