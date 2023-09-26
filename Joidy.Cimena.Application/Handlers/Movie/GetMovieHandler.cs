using Joidy.Cinema.Application.Queries;
using Joidy.Common.DataLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Joidy.Cinema.Application.Handlers.Movie;

public class GetMovieHandler : EntityService<DataLayer.Entities.Movie>, IRequestHandler<GetMoviesQuery, IEnumerable<DataLayer.Entities.Movie>>
{
    public GetMovieHandler(IRepository<DataLayer.Entities.Movie> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<IEnumerable<DataLayer.Entities.Movie>> Handle(GetMoviesQuery query, CancellationToken cancellationToken)
    {
        var movies = await Repository.Select(m => m).ToListAsync();

        return movies;
    }
}