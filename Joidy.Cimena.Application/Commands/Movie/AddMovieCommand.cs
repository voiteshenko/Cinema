using Cinema.Dtos.Request.Movie;
using MediatR;

namespace Cinema.Application.Commands.Movie;

public record AddMovieCommand(AddMovieRequest Request) : IRequest;