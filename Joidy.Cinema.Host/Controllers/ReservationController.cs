using Joidy.Cinema.Application.Commands.Reservation;
using Joidy.Cinema.Dtos.Request.Reservation;
using Joidy.Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace Joidy.Cinema.Host.Controllers;

public class ReservationController : BaseApiController
{
    public readonly IMediator _mediator;

    public ReservationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddReservationRequest request)
    {
        var result = await _mediator.Send(new AddReservationCommand(request));

        return result.Match<IActionResult>(e => BadRequest(e), Ok);
    }

    [HttpPost("approve")]
    public async Task<IActionResult> ApproveReservation(ApproveReservationRequest request)
    {
        var result = await _mediator.Send(new ApproveReservationCommand(request));

        return result.Match<IActionResult>(e => BadRequest(e), Ok);
    }
}