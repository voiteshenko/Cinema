namespace Common.Functional.Either;

public static class EitherAsync
{
    public static async Task<TResult> MatchAsync<TLeft, TRight, TResult>(
        this Either<TLeft, TRight> either,
        Func<TLeft, Task<TResult>> left,
        Func<TRight, Task<TResult>> right) =>
        right == null ? throw new ArgumentNullException(nameof(right)) :
        left == null ? throw new ArgumentNullException(nameof(left)) :
        either.IsRight ? await right(either.Right) : await left(either.Left);
}