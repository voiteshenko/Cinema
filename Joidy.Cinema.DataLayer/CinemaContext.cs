using Cinema.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DataLayer;

public class CinemaContext : DbContext
{
    public CinemaContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<global::Cinema.DataLayer.Entities.Cinema> Cinemas { get; set; }

    public DbSet<Hall> Halls { get; set; }

    public DbSet<Row> Rows { get; set; }

    public DbSet<ShowTime> ShowTimes { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<SeatReservation> SeatReservations { get; set; }
}