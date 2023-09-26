using Joidy.Cinema.Application.Commands.Cinema;
using Joidy.Cinema.DataLayer.Entities;
using Joidy.Common.DataLayer;
using MediatR;

namespace Joidy.Cinema.Application.Handlers.Cinema;

public class AddCinemaHandler : EntityService<DataLayer.Entities.Cinema>, IRequestHandler<AddCinemaCommand, Unit>
{
    public AddCinemaHandler(IRepository<DataLayer.Entities.Cinema> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Unit> Handle(AddCinemaCommand command, CancellationToken cancellationToken)
    {
        await CreateAsync(new DataLayer.Entities.Cinema()
        {
            Id = Guid.NewGuid(),
            Address = command.Request.Address,
            Name = command.Request.Name,
            Halls = command.Request.Halls.Select(hr => new Joidy.Cinema.DataLayer.Entities.Hall
            {
                Id = Guid.NewGuid(),
                Technology = hr.Technology,
                Name = hr.Name,
                Boarding = hr.Boarding,
                Type = hr.Type,
                Rows = hr.Rows.Select(rr => new Row
                {
                    Id = Guid.NewGuid(),
                    ChairType = rr.ChairType,
                    Number = rr.Number,
                    SeatsCount = rr.SeatsCount
                }).ToList()

            }).ToList(),
        });

        return Unit.Value;
    }
}