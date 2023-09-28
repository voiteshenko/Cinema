using Cinema.Common.Enums;

namespace Cinema.Dtos.Request.Cinema;

public class AddRowRequest
{
    public int Number { get; set; }

    public ChairType ChairType { get; set; }

    public int SeatsCount { get; set; }
}