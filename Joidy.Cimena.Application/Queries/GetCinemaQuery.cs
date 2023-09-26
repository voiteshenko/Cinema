using MediatR;

namespace Joidy.Cinema.Application.Queries;

public record GetCinemaQuery : IRequest<IEnumerable<Cinema.DataLayer.Entities.Cinema>>;