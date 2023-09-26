using Joidy.Cinema.Application.Commands.ShowTime;
using Joidy.Cinema.Common;
using Joidy.Common.DataLayer;
using Joidy.Common.Functional.Option;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Joidy.Common.Functional.Option.OptionStatic;


namespace Joidy.Cinema.Application.Handlers.ShowTime;

public class AddShowTimeHandler : EntityService<DataLayer.Entities.ShowTime>, IRequestHandler<AddShowTimeCommand, Option<string>>
{
    private readonly IRepository<DataLayer.Entities.Movie> _movieRepository;
    private readonly IRepository<DataLayer.Entities.Hall> _hallRepository;

    public AddShowTimeHandler(
        IRepository<DataLayer.Entities.ShowTime> repository,
        IUnitOfWork unitOfWork,
        IRepository<DataLayer.Entities.Movie> movieRepository,
        IRepository<DataLayer.Entities.Hall> hallRepository) : base(repository, unitOfWork)
    {
        _movieRepository = movieRepository;
        _hallRepository = hallRepository;
    }

    public async Task<Option<string>> Handle(AddShowTimeCommand command, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.FirstOrDefaultAsync(m => m.Id == command.Request.MovieId);

        if (movie == null)
        {
            return Some(ErrorMessages.MovieNotFound);
        }

        var hall = await _hallRepository.FirstOrDefaultAsync(h => h.Id == command.Request.HallId);

        if (hall == null)
        {
            return Some(ErrorMessages.HallNotFound);
        }

        var showTimeSlotsForDay = await Repository.Where(st => st.StartDate.Date == command.Request.StartDate.Date).ToListAsync();

        var endDate = command.Request.StartDate.Add(movie.Duration);

        if (IsOverlap(command.Request.StartDate, endDate, showTimeSlotsForDay) || IsInsideExisting(command.Request.StartDate, endDate, showTimeSlotsForDay))
        {
            return Some(ErrorMessages.ShowTimeOverlapOrDateInsightExistingOne);
        }

        await CreateAsync(new DataLayer.Entities.ShowTime
        {
            Id = Guid.NewGuid(),
            Movie = movie,
            Hall = hall,
            StartDate = command.Request.StartDate,
            EndDate = endDate
        });

        return None<string>();
    }

    private bool IsOverlap(DateTime startDate, DateTime endDate, IEnumerable<DataLayer.Entities.ShowTime> showTimes)
    {
        foreach (var showTime in showTimes)
        {
            if (startDate < showTime.EndDate && endDate > showTime.StartDate) 
                return true;
        }

        return false;
    }

    private bool IsInsideExisting(DateTime startDate, DateTime endDate, IEnumerable<Joidy.Cinema.DataLayer.Entities.ShowTime> showTimes)
    {
        foreach (var showTime in showTimes)
        {
            if (startDate >= showTime.StartDate && endDate <= showTime.EndDate) 
                return true;
        }

        return false;
    }
}