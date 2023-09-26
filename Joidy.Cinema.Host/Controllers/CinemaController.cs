using Joidy.Cinema.Application.Commands.Cinema;
using Joidy.Cinema.Application.Queries;
using Joidy.Cinema.Dtos.Request.Cinema;
using Joidy.Cinema.Dtos.Response.Cinema;
using Joidy.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Joidy.Cinema.Host.Controllers;

public class CinemaController : BaseApiController
{
    private readonly IMediator _mediator;

    public CinemaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddCinemaRequest request)
    {
        await _mediator.Send(new AddCinemaCommand(request));

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditCinemaRequest request)
    {
        var result = await _mediator.Send(new EditCinemaCommand(request));

        return result.Match<IActionResult>(e => BadRequest(e), Ok);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetCinemaQuery());

        return Ok(result.Select(c => new GetCinemaResponse
        {
            Id = c.Id,
            Name = c.Name,
            Address = c.Address,
            Halls = c.Halls.Select(h => new GetHallResponse
            {
                Id = h.Id,
                Name = h.Name,
                Boarding = h.Boarding,
                Technology = h.Technology,
                Type = h.Type,
                Rows = h.Rows.Select(r => new GetRowResponse()
                {
                    Id = r.Id,
                    ChairType = r.ChairType,
                    SeatsCount = r.SeatsCount,
                    Number = r.Number
                })
            })
        }));
    }
}