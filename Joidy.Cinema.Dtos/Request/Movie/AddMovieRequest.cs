using Cinema.Common.Enums;

namespace Cinema.Dtos.Request.Movie;

public class AddMovieRequest
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public Genre Genre { get; set; }

    public int Year { get; set; }

    public int MinimalAge { get; set; }

    public string? Director { get; set; }

    public TimeSpan Duration { get; set; }

    public string? Studio { get; set; }
}