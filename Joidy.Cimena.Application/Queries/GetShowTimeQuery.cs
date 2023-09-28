using Cinema.DataLayer.Entities;
using MediatR;

namespace Cinema.Application.Queries;

public record GetShowTimeQuery(DateTime Date) : IRequest<IEnumerable<ShowTime>>;