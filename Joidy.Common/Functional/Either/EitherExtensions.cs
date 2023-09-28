using Joidy.Common.Functional.Option;

namespace Common.Functional.Either;

public static class EitherExtensions
{
    public static Either<TLeft, TRight> Left<TLeft, TRight>(this TLeft value) => Either.Left<TLeft, TRight>(value);

    public static Either<TLeft, TRight> Left<TLeft, TRight>(this TRight value) => Either.Right<TLeft, TRight>(value);

    public static Option<TRight> ToOption<TLeft, TRight>(this Either<TLeft, TRight> either) =>
        either.IsRight ? OptionStatic.Some(either.Right) : OptionStatic.None<TRight>();
}