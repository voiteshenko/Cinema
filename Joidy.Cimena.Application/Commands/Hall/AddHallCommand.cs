using Cinema.Dtos.Request.Hall;
using Joidy.Common.Functional.Option;
using MediatR;

namespace Cinema.Application.Commands.Hall;

public record AddHallCommand(AddHallToCinemaRequest Request) : IRequest<Option<string>>;
