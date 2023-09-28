using Cinema.Common.Enums;

namespace Cinema.Dtos.Response.Cinema;

public class GetRowResponse
{
    public Guid Id { get; set; }

    public int Number { get; set; }

    public ChairType ChairType { get; set; }

    public int SeatsCount { get; set; }
}