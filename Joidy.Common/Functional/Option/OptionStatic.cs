using System.Diagnostics.CodeAnalysis;

namespace Joidy.Common.Functional.Option;

[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:SA1649FileNameMustMatchTypeName", Justification = "Reviewed.")]
public static class OptionStatic
{
    public static Option<T> Some<T>(T value) => new Option<T>(value, true);

    public static Option<T> None<T>() => new Option<T>(default, false);
}