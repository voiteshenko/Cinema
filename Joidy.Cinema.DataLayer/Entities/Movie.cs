using Cinema.Common.Enums;

namespace Cinema.DataLayer.Entities;

public class Movie
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Genre Genre { get; set; }

    public int Year { get; set; }
        
    public int MinimalAge { get; set; }

    public string Director { get; set; }

    public TimeSpan Duration { get; set; }

    public string Studio { get; set; }
}