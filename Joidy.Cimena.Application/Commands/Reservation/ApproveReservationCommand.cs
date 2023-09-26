using Joidy.Cinema.Dtos.Request.Reservation;
using Joidy.Common.Functional.Option;
using MediatR;

namespace Joidy.Cinema.Application.Commands.Reservation;

public record ApproveReservationCommand(ApproveReservationRequest Request) : IRequest<Option<string>>;