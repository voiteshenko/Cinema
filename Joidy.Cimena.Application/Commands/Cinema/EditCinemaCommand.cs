using Joidy.Cinema.Dtos.Request.Cinema;
using Joidy.Common.Functional.Option;
using MediatR;

namespace Joidy.Cinema.Application.Commands.Cinema;

public record EditCinemaCommand(EditCinemaRequest Request) : IRequest<Option<string>>;