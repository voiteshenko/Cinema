using Joidy.Cinema.Dtos.Request.Movie;
using MediatR;

namespace Joidy.Cinema.Application.Commands.Movie;

public record AddMovieCommand(AddMovieRequest Request) : IRequest;