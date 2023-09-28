using Cinema.Application.Handlers.Movie;
using Cinema.Application.Services;
using Cinema.Application.Services.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IReservationService, ReservationService>();

        services.AddMediatR(typeof(AddMovieHandler).Assembly);
        services.AddRepositoriesAndUnitOfWork();

        return services;
    }
}