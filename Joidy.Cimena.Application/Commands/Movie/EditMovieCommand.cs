using Joidy.Cinema.Dtos.Request.Movie;
using Joidy.Common.Functional.Option;
using MediatR;

namespace Joidy.Cinema.Application.Commands.Movie;

public record EditMovieCommand(EditMovieRequest Request) : IRequest<Option<string>>;