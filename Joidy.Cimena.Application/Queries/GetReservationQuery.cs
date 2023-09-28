using Cinema.DataLayer.Entities;
using MediatR;

namespace Cinema.Application.Queries;

public record GetReservationQuery(Guid id) : IRequest<Reservation>;