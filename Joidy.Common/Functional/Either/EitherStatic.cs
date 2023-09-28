using System.Diagnostics.CodeAnalysis;

namespace Common.Functional.Either;

[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:SA1649FileNameMustMatchTypeName", Justification = "Reviewed.")]
public static class Either
{
    public static Either<TLeft, TRight> Left<TLeft, TRight>(TLeft left) => new Either<TLeft, TRight>(left);

    public static Either<TLeft, TRight> Right<TLeft, TRight>(TRight right) => new Either<TLeft, TRight>(right);
}