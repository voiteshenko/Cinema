using Joidy.Cinema.Common.Enums;

namespace Joidy.Cinema.DataLayer.Entities;

public class Hall
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public HallType Type { get; set; }

    public HallTechnologyType Technology { get; set; }

    public string Boarding { get; set; }

    public Cinema Cinema { get; set; }

    public ICollection<Row> Rows { get; set; }
}