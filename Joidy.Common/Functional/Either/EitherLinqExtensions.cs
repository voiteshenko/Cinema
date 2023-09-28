namespace Common.Functional.Either;

public static class EitherLinqExtensions
{
    public static Either<TLeft, TResult> Select<TLeft, TRight, TResult>(this Either<TLeft, TRight> source,
        Func<TRight, TResult> selector) =>
        selector == null ? throw new ArgumentNullException(nameof(selector)) : source.Map(selector);

    public static Either<TLeft, TResult> SelectMany<TLeft, TRight, TResult>(this Either<TLeft, TRight> source,
        Func<TRight, Either<TLeft, TResult>> selector) => selector == null
        ? throw new ArgumentNullException(nameof(selector))
        : source.Bind(selector);

    public static Either<TLeft, TResult> SelectMany<TLeft, TRight, TCollection, TResult>(
        this Either<TLeft, TRight> source,
        Func<TRight, Either<TLeft, TCollection>> collectionSelector,
        Func<TRight, TCollection, TResult> resultSelector) =>
        collectionSelector == null
            ? throw new ArgumentNullException(nameof(collectionSelector))
            : resultSelector == null
                ? throw new ArgumentNullException(nameof(resultSelector))
                : source.Bind(src => collectionSelector(src).Map(elem => resultSelector(src, elem)));

    public static Either<TLeft, TRight> Where<TLeft, TRight>(this Either<TLeft, TRight> source,
        Func<TRight, bool> predicate) =>
        predicate == null ? throw new ArgumentNullException(nameof(predicate)) : source.Filter(predicate);
}