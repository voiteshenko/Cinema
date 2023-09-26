namespace Joidy.Common.Functional.Either;

public readonly struct Either<TLeft, TRight> : IEquatable<Either<TLeft, TRight>>, IComparable<Either<TLeft, TRight>>
    where TLeft : notnull
    where TRight : notnull
{
    private readonly TLeft _left;
    private readonly TRight _right;

    internal Either(TLeft left)
    {
        _left = left;
        _right = default;
        IsLeft = true;
    }

    internal Either(TRight right)
    {
        _left = default;
        _right = right;
        IsLeft = false;
    }

    public bool IsLeft { get; }

    public bool IsRight => !IsLeft;

    internal TLeft Left => !IsLeft ? throw new InvalidOperationException("Not in the left state") : _left;

    internal TRight Right => !IsRight ? throw new InvalidOperationException("Not in the right state") : _right;

    public static bool operator ==(Either<TLeft, TRight> left, Either<TLeft, TRight> right) => left.Equals(right);

    public static bool operator !=(Either<TLeft, TRight> left, Either<TLeft, TRight> right) => !left.Equals(right);

    public static bool operator <(Either<TLeft, TRight> left, Either<TLeft, TRight> right) =>
        left.CompareTo(right) < 0;

    public static bool operator <=(Either<TLeft, TRight> left, Either<TLeft, TRight> right) =>
        left.CompareTo(right) <= 0;

    public static bool operator >(Either<TLeft, TRight> left, Either<TLeft, TRight> right) =>
        left.CompareTo(right) > 0;

    public static bool operator >=(Either<TLeft, TRight> left, Either<TLeft, TRight> right) =>
        left.CompareTo(right) >= 0;

    public bool Equals(Either<TLeft, TRight> other) =>
        IsRight && other.IsRight
            ? EqualityComparer<TRight>.Default.Equals(Right, other.Right)
            : IsLeft && other.IsLeft && EqualityComparer<TLeft>.Default.Equals(Left, other.Left);

    public override bool Equals(object obj) => obj is Either<TLeft, TRight> either && Equals(either);

    public override int GetHashCode() => IsRight ? _right.GetHashCode() : IsLeft ? _left.GetHashCode() : 0;

    public int CompareTo(Either<TLeft, TRight> other)
    {
        if (IsRight && !other.IsRight)
        {
            return 1;
        }

        if (!IsRight && !other.IsRight)
        {
            return Comparer<TLeft>.Default.Compare(Left, other.Left);
        }

        return Comparer<TRight>.Default.Compare(Right, other.Right);
    }

    public override string ToString() => IsRight ? $"Right ({Right})" : $"Left ({Left})";

    public IEnumerable<TRight> ToEnumerable()
    {
        if (IsRight)
        {
            yield return Right;
        }
    }

    public IEnumerator<TRight> GetEnumerator()
    {
        if (IsRight)
        {
            yield return Right;
        }
    }

    public Either<TLeft, TResult> Bind<TResult>(Func<TRight, Either<TLeft, TResult>> mapping) =>
        mapping == null
            ? throw new ArgumentNullException(nameof(mapping))
            : Match(Either.Left<TLeft, TResult>, mapping);

    public bool Contains(TRight value) => IsRight && Right.Equals(value);

    public bool Exists(Func<TRight, bool> predicate) => predicate == null
        ? throw new ArgumentNullException(nameof(predicate))
        : IsRight && predicate(Right);

    public Either<TLeft, TRight> Filter(Func<TRight, bool> predicate) =>
        predicate == null
            ? throw new ArgumentNullException(nameof(predicate))
            : !IsRight
                ? this
                : predicate(Right)
                    ? this
                    : throw new InvalidOperationException("This causes the Bottom state of Either");

    public Either<TLeft, TResult> Map<TResult>(Func<TRight, TResult> mapping) =>
        mapping == null
            ? throw new ArgumentNullException(nameof(mapping))
            : Match(Either.Left<TLeft, TResult>, right => Either.Right<TLeft, TResult>(mapping(right)));

    public TResult Match<TResult>(Func<TLeft, TResult> left, Func<TRight, TResult> right) =>
        right == null ? throw new ArgumentNullException(nameof(right)) :
        left == null ? throw new ArgumentNullException(nameof(left)) :
        IsRight ? right(Right) : left(Left);
}