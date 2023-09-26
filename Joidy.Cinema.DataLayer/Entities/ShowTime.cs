namespace Joidy.Cinema.DataLayer.Entities;

public class ShowTime
{
    public Guid Id { get; set; }

    public Hall Hall { get; set; }

    public Movie Movie { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}