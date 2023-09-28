using Cinema.DataLayer.Entities;
using MediatR;

namespace Cinema.Application.Queries
{
    public record GetMoviesQuery : IRequest<IEnumerable<Movie>>;
}
