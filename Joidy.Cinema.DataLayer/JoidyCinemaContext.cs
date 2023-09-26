using Joidy.Cinema.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Joidy.Cinema.DataLayer;

public class JoidyCinemaContext : DbContext
{
    public JoidyCinemaContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<Entities.Cinema> Cinemas { get; set; }

    public DbSet<Hall> Halls { get; set; }

    public DbSet<Row> Rows { get; set; }

    public DbSet<ShowTime> ShowTimes { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<SeatReservation> SeatReservations { get; set; }
}