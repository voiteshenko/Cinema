using Joidy.Cinema.DataLayer.Entities;
using MediatR;

namespace Joidy.Cinema.Application.Queries;

public record GetShowTimeQuery(DateTime Date) : IRequest<IEnumerable<ShowTime>>;