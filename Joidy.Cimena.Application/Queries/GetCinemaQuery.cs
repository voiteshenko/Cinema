using MediatR;

namespace Cinema.Application.Queries;

public record GetCinemaQuery : IRequest<IEnumerable<DataLayer.Entities.Cinema>>;