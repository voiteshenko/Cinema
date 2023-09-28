using Cinema.Common.Enums;

namespace Cinema.Dtos.Response.Cinema;

public class GetHallResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public HallType Type { get; set; }

    public HallTechnologyType Technology { get; set; }

    public string Boarding { get; set; }

    public IEnumerable<GetRowResponse> Rows { get; set; }
}