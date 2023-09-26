using Joidy.Cinema.Dtos.Request.ShowTime;
using Joidy.Common.Functional.Option;
using MediatR;

namespace Joidy.Cinema.Application.Commands.ShowTime;

public record AddShowTimeCommand(AddShowTimeRequest Request) : IRequest<Option<string>>;