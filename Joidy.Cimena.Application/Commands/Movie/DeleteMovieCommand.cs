using Joidy.Common.Functional.Option;
using MediatR;

namespace Joidy.Cinema.Application.Commands.Movie;

public record DeleteMovieCommand(Guid Id) : IRequest<Option<string>>;