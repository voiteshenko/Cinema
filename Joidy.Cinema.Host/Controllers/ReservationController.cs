using Cinema.Application.Commands.Reservation;
using Cinema.Application.Queries;
using Cinema.Dtos.Request.Reservation;
using Cinema.Dtos.Response.Reservation;
using Common.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Host.Controllers;

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

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] Guid id)
    {
        var result = await _mediator.Send(new GetReservationQuery(id));

        return result == null
            ? NotFound()
            : Ok(new GetReservationResponse
            {
                Id = result.Id,
                Movie = result.ShowTime.Movie.Name,
                Description = result.ShowTime.Movie.Description,
                StartDate = result.ShowTime.StartDate,
                TotalPrice = result.TotalPrice,
                IsApproved = result.IsApproved,
                Email = result.Email,
                SeatReservations = result.SeatReservations.Select(sr => new GetSeatReservationResponse
                {
                    RowNumber = sr.RowNumber,
                    SeatNumber = sr.SeatNumber
                })
            });
    }
}