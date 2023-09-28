namespace Cinema.Common;

public class ErrorMessages
{
    public const string MovieNotFound = nameof(MovieNotFound);
    public const string CinemaNotFound = nameof(CinemaNotFound);
    public const string HallNotFound = nameof(HallNotFound);
    public const string ShowTimeOverlapOrDateInsightExistingOne = nameof(ShowTimeOverlapOrDateInsightExistingOne);
    public const string ShowTimeNotFound = nameof(ShowTimeNotFound);
    public const string ReservationAlreadyExist = nameof(ReservationAlreadyExist);
    public const string ReservationNotFound = nameof(ReservationNotFound);

    //Validation error messages
    public const string NameShouldNotBeEmpty = nameof(NameShouldNotBeEmpty);
    public const string DescriptionShouldNotBeEmpty = nameof(DescriptionShouldNotBeEmpty);
    public const string InvalidValueForYear = nameof(InvalidValueForYear);
    public const string InvalidValueForMinimalAge = nameof(InvalidValueForMinimalAge);
    public const string DirectorShouldNotBeEmpty = nameof(DirectorShouldNotBeEmpty);
    public const string StudioShouldNotBeEmpty = nameof(StudioShouldNotBeEmpty);
    public const string InvalidGenreValue = nameof(InvalidGenreValue);
    public const string InvalidMovieId = nameof(InvalidMovieId);
    public const string CinemaIdNotValid = nameof(CinemaIdNotValid);
    public const string BoardingShouldNotBeEmpty = nameof(BoardingShouldNotBeEmpty);
    public const string InvalidHallTechnologyType = nameof(InvalidHallTechnologyType);
    public const string InvalidHallType = nameof(InvalidHallType);
    public const string InvalidHallRows = nameof(InvalidHallRows);
    public const string AddressShouldNotBeEmpty = nameof(AddressShouldNotBeEmpty);
    public const string HallsShouldNotBeEmpty = nameof(HallsShouldNotBeEmpty);
    public const string InvalidMailValue = nameof(InvalidMailValue);
    public const string InvalidValueForShowTimeId = nameof(InvalidValueForShowTimeId);
    public const string SeatReservationsShouldNotBeEmpty = nameof(SeatReservationsShouldNotBeEmpty);
    public const string InvalidValueForReservationId = nameof(InvalidValueForReservationId);
    public const string InvalidValueForStartDate = nameof(InvalidValueForStartDate);
    public const string InvalidValueForHallId = nameof(InvalidValueForHallId);
    public const string InvalidValueForMovieId = nameof(InvalidValueForMovieId);
}