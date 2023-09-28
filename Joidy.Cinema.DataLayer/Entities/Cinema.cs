namespace Cinema.DataLayer.Entities;

public class Cinema
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public ICollection<Hall> Halls { get; set; }
}