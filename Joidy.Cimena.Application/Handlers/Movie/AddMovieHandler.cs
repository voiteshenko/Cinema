using Cinema.Application.Commands.Movie;
using Common.DataLayer;
using MediatR;

namespace Cinema.Application.Handlers.Movie;

public class AddMovieHandler : EntityService<DataLayer.Entities.Movie>, IRequestHandler<AddMovieCommand, Unit>
{
    public AddMovieHandler(IRepository<DataLayer.Entities.Movie> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Unit> Handle(AddMovieCommand command, CancellationToken cancellationToken)
    {
        await CreateAsync(new DataLayer.Entities.Movie
        {
            Id = Guid.NewGuid(),
            Description = command.Request.Description,
            Director = command.Request.Director,
            Duration = command.Request.Duration,
            Genre = command.Request.Genre,
            MinimalAge = command.Request.MinimalAge,
            Name = command.Request.Name,
            Studio = command.Request.Studio,
            Year = command.Request.Year,
        });

        return Unit.Value;
    }
}