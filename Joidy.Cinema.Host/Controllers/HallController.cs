using Joidy.Cinema.Application.Commands.Hall;
using Joidy.Cinema.Dtos.Request.Hall;
using Joidy.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Joidy.Cinema.Host.Controllers;

public class HallController : BaseApiController
{
    private readonly IMediator _mediator;

    public HallController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddHallToCinemaRequest request)
    {
        var result = await _mediator.Send(new AddHallCommand(request));

        return result.Match<IActionResult>(e => BadRequest(e), Ok);
    }
}