using Joidy.Cinema.Application.Commands.ShowTime;
using Joidy.Cinema.Application.Queries;
using Joidy.Cinema.Dtos.Request.ShowTime;
using Joidy.Cinema.Dtos.Response.ShowTime;
using Joidy.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Joidy.Cinema.Host.Controllers;

public class ShowTimeController : BaseApiController
{
    private readonly IMediator _mediator;

    public ShowTimeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddShowTimeRequest request)
    {
        var result = await _mediator.Send(new AddShowTimeCommand(request));

        return result.Match<IActionResult>(e => BadRequest(e), Ok);
    }

    [HttpGet]
    public async Task<IActionResult> GetForDate([FromQuery] DateTime date)
    {
        var result = await _mediator.Send(new GetShowTimeQuery(date));

        return Ok(result.Select(st => new GetShowTimeResponse
        {
            Id = st.Id,
            StartDate = st.StartDate,
            EndDate = st.EndDate,
            HallName = st.Hall.Name,
            MovieName = st.Movie.Name,
            MovieDescription = st.Movie.Description
        }).ToList());
    }
}