using Cinema.Application.Commands.Movie;
using Cinema.Application.Queries;
using Cinema.Dtos.Request.Movie;
using Cinema.Dtos.Response.Movie;
using Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Host.Controllers;

public class MovieController : BaseApiController
{
    private readonly IMediator _mediator;

    public MovieController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddMovieRequest request)
    {
        await _mediator.Send(new AddMovieCommand(request));

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditMovieRequest request)
    {
        var result = await _mediator.Send(new EditMovieCommand(request));

        return result.Match<IActionResult>(e => BadRequest(e), Ok);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var result = await _mediator.Send(new DeleteMovieCommand(id));

        return result.Match<IActionResult>(e => BadRequest(e), Ok);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetMoviesQuery());

        return result.Any()
            ? Ok(result.Select(m => new GetMovieResponse
            {
                Id = m.Id,
                Description = m.Description,
                Director = m.Director,
                Duration = m.Duration,
                Genre = m.Genre,
                MinimalAge = m.MinimalAge,
                Name = m.Name,
                Studio = m.Studio,
                Year = m.Year
            }))
            : NotFound();
    }
}