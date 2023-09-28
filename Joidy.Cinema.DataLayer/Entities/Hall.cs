using Cinema.Common.Enums;

namespace Cinema.DataLayer.Entities;

public class Hall
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public HallType Type { get; set; }

    public HallTechnologyType Technology { get; set; }

    public string Boarding { get; set; }

    public global::Cinema.DataLayer.Entities.Cinema Cinema { get; set; }

    public ICollection<Row> Rows { get; set; }
}