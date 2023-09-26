namespace Joidy.Common.Functional.Option;

public static class OptionAsync
{
    public static async Task<TResult> MatchAsync<T, TResult>(
        this Option<T> option,
        Func<T, Task<TResult>> some,
        Func<Task<TResult>> none) =>
        some == null ? throw new ArgumentNullException(nameof(some)) :
        none == null ? throw new ArgumentNullException(nameof(none)) :
        option.IsSome ? await some(option.Value) : await none();
}