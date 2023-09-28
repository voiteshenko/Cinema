using Cinema.Application.Commands.Movie;
using Cinema.Common;
using Common.DataLayer;
using Joidy.Common.Functional.Option;
using MediatR;
using static Joidy.Common.Functional.Option.OptionStatic;

namespace Cinema.Application.Handlers.Movie;

public class DeleteMovieHandler : EntityService<DataLayer.Entities.Movie>, IRequestHandler<DeleteMovieCommand, Option<string>>
{
    public DeleteMovieHandler(IRepository<DataLayer.Entities.Movie> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Option<string>> Handle(DeleteMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await FindAsync(new object[] { command.Id });

        if (movie == null)
        {
            return Some(ErrorMessages.MovieNotFound);
        }

        await DeleteAsync(movie);

        return None<string>();
    }
}