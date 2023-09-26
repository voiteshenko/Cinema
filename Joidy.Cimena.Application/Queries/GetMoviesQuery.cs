using Joidy.Cinema.DataLayer.Entities;
using MediatR;

namespace Joidy.Cinema.Application.Queries
{
    public record GetMoviesQuery : IRequest<IEnumerable<Movie>>;
}
