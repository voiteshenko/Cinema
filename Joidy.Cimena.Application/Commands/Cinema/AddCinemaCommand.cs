using Cinema.Dtos.Request.Cinema;
using MediatR;

namespace Cinema.Application.Commands.Cinema;

public record AddCinemaCommand(AddCinemaRequest Request) : IRequest;