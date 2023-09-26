using Joidy.Cinema.Dtos.Request.Cinema;
using MediatR;

namespace Joidy.Cinema.Application.Commands.Cinema;

public record AddCinemaCommand(AddCinemaRequest Request) : IRequest;