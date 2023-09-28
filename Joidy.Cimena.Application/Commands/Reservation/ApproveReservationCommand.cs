using Cinema.Dtos.Request.Reservation;
using Joidy.Common.Functional.Option;
using MediatR;

namespace Cinema.Application.Commands.Reservation;

public record ApproveReservationCommand(ApproveReservationRequest Request) : IRequest<Option<string>>;