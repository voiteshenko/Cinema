using Joidy.Cinema.Dtos.Request.Hall;
using Joidy.Common.Functional.Option;
using MediatR;

namespace Joidy.Cinema.Application.Commands.Hall;

public record AddHallCommand(AddHallToCinemaRequest Request) : IRequest<Option<string>>;
