using FluentValidation;
using Joidy.Cinema.Common;
using Joidy.Cinema.Dtos.Request.Movie;

namespace Joidy.Cinema.Host.Validation.Movie
{
    public class AddMovieValidator : AbstractValidator<AddMovieRequest>
    {
        private int[] genreIds = { 0, 1, 2, 3, 4 };

        public AddMovieValidator()
        {
            RuleFor(m => m.Name).NotNull().NotEmpty().WithMessage(ErrorMessages.NameShouldNotBeEmpty);
            RuleFor(m => m.Description).NotNull().NotEmpty().WithMessage(ErrorMessages.DescriptionShouldNotBeEmpty);
            RuleFor(m => m.Year).GreaterThanOrEqualTo(1888).WithMessage(ErrorMessages.InvalidValueForYear);
            RuleFor(m => m.MinimalAge).GreaterThanOrEqualTo(0).WithMessage(ErrorMessages.InvalidValueForMinimalAge);
            RuleFor(m => m.Director).NotNull().NotEmpty().WithMessage(ErrorMessages.DirectorShouldNotBeEmpty);
            RuleFor(m => m.Studio).NotNull().NotEmpty().WithMessage(ErrorMessages.StudioShouldNotBeEmpty);
            RuleFor(m => m.Genre).Must((m, c) => IsGenreValid(m)).WithMessage(ErrorMessages.InvalidGenreValue);
        }

        private bool IsGenreValid(AddMovieRequest request)
        {
            return genreIds.Any(gid => gid == (int)request.Genre);
        }
    }
}