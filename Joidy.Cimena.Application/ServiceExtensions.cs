using Joidy.Cinema.Application.Handlers.Movie;
using Joidy.Cinema.Application.Services;
using Joidy.Cinema.Application.Services.Abstractions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Joidy.Cinema.Application;

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