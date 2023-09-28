using Cinema.Application.Queries;
using Common.DataLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Handlers.Cinema;

public class GetCinemaHandler : EntityService<DataLayer.Entities.Cinema>, IRequestHandler<GetCinemaQuery, IEnumerable<DataLayer.Entities.Cinema>>
{
    public GetCinemaHandler(IRepository<DataLayer.Entities.Cinema> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<IEnumerable<DataLayer.Entities.Cinema>> Handle(GetCinemaQuery query, CancellationToken cancellationToken)
    {
        var cinemas = await Repository
            .Select(c => c)
            .Include(c=>c.Halls)
            .ThenInclude(h=>h.Rows)
            .ToListAsync();

        return cinemas;
    }
}