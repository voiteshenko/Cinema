namespace Joidy.Common.Functional.Option;

public static class OptionLinqExtensions
{
    public static Option<TResult> Select<TSource, TResult>(this Option<TSource> source,
        Func<TSource, TResult> selector) =>
        selector == null ? throw new ArgumentNullException(nameof(selector)) : source.Map(selector);

    public static Option<TResult> SelectMany<TSource, TResult>(this Option<TSource> source,
        Func<TSource, Option<TResult>> selector) => selector == null
        ? throw new ArgumentNullException(nameof(selector))
        : source.Bind(selector);

    public static Option<TResult> SelectMany<TSource, TCollection, TResult>(
        this Option<TSource> source,
        Func<TSource, Option<TCollection>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector) =>
        collectionSelector == null
            ? throw new ArgumentNullException(nameof(collectionSelector))
            : resultSelector == null
                ? throw new ArgumentNullException(nameof(resultSelector))
                : source.Bind(src => collectionSelector(src).Map(elem => resultSelector(src, elem)));

    public static Option<TSource> Where<TSource>(this Option<TSource> source, Func<TSource, bool> predicate) =>
        predicate == null ? throw new ArgumentNullException(nameof(predicate)) : source.Filter(predicate);
}