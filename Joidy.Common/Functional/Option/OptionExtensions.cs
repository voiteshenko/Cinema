namespace Joidy.Common.Functional.Option;

public static class OptionExtensions
{
    public static Option<T> Some<T>(this T value) => OptionStatic.Some(value);

    public static Option<T> None<T>(this T value) => OptionStatic.None<T>();

    public static T? ToNullable<T>(this Option<T> option)
        where T : struct =>
        option.IsSome ? option.Value : default(T?);

    public static T ValueOrDefault<T>(this Option<T> option) => option.IsSome ? option.Value : default;
}