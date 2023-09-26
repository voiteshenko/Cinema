using Joidy.Cinema.Common.Enums;

namespace Joidy.Cinema.Dtos.Request.Cinema;

public class AddHallRequest
{
    public string? Name { get; set; }

    public HallType Type { get; set; }

    public HallTechnologyType Technology { get; set; }

    public string? Boarding { get; set; }

    public IEnumerable<AddRowRequest>? Rows { get; set; }
}