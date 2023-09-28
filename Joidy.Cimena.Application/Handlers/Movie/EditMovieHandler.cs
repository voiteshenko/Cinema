using Cinema.Application.Commands.Movie;
using Cinema.Common;
using Common.DataLayer;
using Joidy.Common.Functional.Option;
using MediatR;
using static Joidy.Common.Functional.Option.OptionStatic;

namespace Cinema.Application.Handlers.Movie;

public class EditMovieHandler : EntityService<DataLayer.Entities.Movie>, IRequestHandler<EditMovieCommand, Option<string>>
{
    public EditMovieHandler(IRepository<DataLayer.Entities.Movie> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Option<string>> Handle(EditMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await FindAsync(new object[] { command.Request.Id });

        if (movie == null)
        {
            return Some(ErrorMessages.MovieNotFound);
        }

        movie.Description = command.Request.Description;
        movie.Director = command.Request.Director;
        movie.Duration = command.Request.Duration;
        movie.Genre = command.Request.Genre;
        movie.MinimalAge = command.Request.MinimalAge;
        movie.Year = command.Request.Year;
        movie.Name = command.Request.Name;
        movie.Studio = command.Request.Studio;

        await UpdateAsync(movie);

        return None<string>();
    }
}