using Joidy.Cinema.Application.Commands.Hall;
using Joidy.Cinema.Common;
using Joidy.Cinema.DataLayer.Entities;
using Joidy.Common.DataLayer;
using Joidy.Common.Functional.Option;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Joidy.Common.Functional.Option.OptionStatic;

namespace Joidy.Cinema.Application.Handlers.Hall;

public class AddHallHandler : EntityService<DataLayer.Entities.Hall>, IRequestHandler<AddHallCommand, Option<string>>
{
    private readonly IRepository<DataLayer.Entities.Cinema> _cinemaRepository;

    public AddHallHandler(
        IRepository<DataLayer.Entities.Hall> repository,
        IUnitOfWork unitOfWork,
        IRepository<DataLayer.Entities.Cinema> cinemaRepository) : base(repository, unitOfWork)
    {
        _cinemaRepository = cinemaRepository;
    }

    public async Task<Option<string>> Handle(AddHallCommand command, CancellationToken cancellationToken)
    {
        var cinema = await _cinemaRepository.FirstOrDefaultAsync(c => c.Id == command.Request.CinemaId);

        if (cinema == null)
        {
            return Some(ErrorMessages.MovieNotFound);
        }

        await CreateAsync(new Joidy.Cinema.DataLayer.Entities.Hall
        {
            Id = Guid.NewGuid(),
            Boarding = command.Request.Boarding,
            Name = command.Request.Name,
            Technology = command.Request.Technology,
            Type = command.Request.Type,
            Cinema = cinema,
            Rows = command.Request.Rows.Select(r => new Row
            {
                Id = Guid.NewGuid(),
                ChairType = r.ChairType,
                SeatsCount = r.SeatsCount,
                Number = r.Number
            }).ToList()
        });

        return None<string>();
    }
}