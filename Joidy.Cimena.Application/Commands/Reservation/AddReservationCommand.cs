using Cinema.Dtos.Request.Reservation;
using Joidy.Common.Functional.Option;
using MediatR;

namespace Cinema.Application.Commands.Reservation;

public record AddReservationCommand(AddReservationRequest Request) : IRequest<Option<string>>;