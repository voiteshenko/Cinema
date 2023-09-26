using Joidy.Cinema.Application.Commands.Cinema;
using Joidy.Cinema.Common;
using Joidy.Common.DataLayer;
using Joidy.Common.Functional.Option;
using MediatR;
using static Joidy.Common.Functional.Option.OptionStatic;

namespace Joidy.Cinema.Application.Handlers.Cinema;

public class EditCinemaHandler : EntityService<DataLayer.Entities.Cinema>, IRequestHandler<EditCinemaCommand, Option<string>>
{
    public EditCinemaHandler(IRepository<DataLayer.Entities.Cinema> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
    public async Task<Option<string>> Handle(EditCinemaCommand command, CancellationToken cancellationToken)
    {
        var cinema = await FindAsync(new object[] { command.Request.Id });

        if (cinema == null)
        {
            return Some(ErrorMessages.CinemaNotFound);
        }

        cinema.Address = command.Request.Address;
        cinema.Name = command.Request.Name;

        await UpdateAsync(cinema);

        return None<string>();
    }
}