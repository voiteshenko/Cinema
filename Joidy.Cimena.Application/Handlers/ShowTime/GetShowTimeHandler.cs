using Joidy.Cinema.Application.Queries;
using Joidy.Common.DataLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Joidy.Cinema.Application.Handlers.ShowTime;

public class GetShowTimeHandler : EntityService<DataLayer.Entities.ShowTime>, IRequestHandler<GetShowTimeQuery, IEnumerable<DataLayer.Entities.ShowTime>>
{
    public GetShowTimeHandler(IRepository<DataLayer.Entities.ShowTime> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }
    public async Task<IEnumerable<DataLayer.Entities.ShowTime>> Handle(GetShowTimeQuery query, CancellationToken cancellationToken)
    {
        var showTimes = await Repository
            .Where(st => st.StartDate.Day == query.Date.Day)
            .Include(st => st.Hall)
            .Include(st => st.Movie)
            .ToListAsync();

        return showTimes;
    }
}