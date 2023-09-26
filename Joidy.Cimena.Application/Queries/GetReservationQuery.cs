using Joidy.Cinema.DataLayer.Entities;
using MediatR;

namespace Joidy.Cinema.Application.Queries;

public record GetReservationQuery(Guid id) : IRequest<Reservation>;