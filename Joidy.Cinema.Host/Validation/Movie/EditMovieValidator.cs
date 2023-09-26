using FluentValidation;
using Joidy.Cinema.Common;
using Joidy.Cinema.Dtos.Request.Movie;

namespace Joidy.Cinema.Host.Validation.Movie;

public class EditMovieValidator : AbstractValidator<EditMovieRequest>
{
    private int[] genreIds = { 0, 1, 2, 3, 4 };

    public EditMovieValidator()
    {
        RuleFor(m => m.Id).Must((m, c) => IsMovieIdValid(m)).WithMessage(ErrorMessages.InvalidMovieId);
        RuleFor(m => m.Name).NotNull().NotEmpty().WithMessage(ErrorMessages.NameShouldNotBeEmpty);
        RuleFor(m => m.Description).NotNull().NotEmpty().WithMessage(ErrorMessages.DescriptionShouldNotBeEmpty);
        RuleFor(m => m.Year).GreaterThanOrEqualTo(1888).WithMessage(ErrorMessages.InvalidValueForYear);
        RuleFor(m => m.MinimalAge).GreaterThanOrEqualTo(0).WithMessage(ErrorMessages.InvalidValueForMinimalAge);
        RuleFor(m => m.Director).NotNull().NotEmpty().WithMessage(ErrorMessages.DirectorShouldNotBeEmpty);
        RuleFor(m => m.Studio).NotNull().NotEmpty().WithMessage(ErrorMessages.StudioShouldNotBeEmpty);
        RuleFor(m => m.Genre).Must((m, c) => IsGenreValid(m)).WithMessage(ErrorMessages.InvalidGenreValue);
    }

    private bool IsGenreValid(EditMovieRequest request)
    {
        return genreIds.Any(gid => gid == (int)request.Genre);
    }

    private bool IsMovieIdValid(EditMovieRequest request)
    {
        return request.Id != Guid.Empty;
    }
}