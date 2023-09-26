using static Joidy.Common.Functional.Option.OptionStatic;

namespace Joidy.Common.Functional.Option;

public readonly struct Option<T> : IEquatable<Option<T>>, IComparable<Option<T>>
{
    // Don't convert it to auto-property. This would cause struct copying
    private readonly T _value;

    internal Option(T value, bool isSome)
    {
        _value = value;
        IsSome = isSome;
    }

    public bool IsSome { get; }

    internal T Value => _value;

    public static implicit operator Option<T>(T value) => value == null ? None<T>() : Some(value);

    public static bool operator ==(Option<T> left, Option<T> right) => left.Equals(right);

    public static bool operator !=(Option<T> left, Option<T> right) => !left.Equals(right);

    public static bool operator <(Option<T> left, Option<T> right) => left.CompareTo(right) < 0;

    public static bool operator <=(Option<T> left, Option<T> right) => left.CompareTo(right) <= 0;

    public static bool operator >(Option<T> left, Option<T> right) => left.CompareTo(right) > 0;

    public static bool operator >=(Option<T> left, Option<T> right) => left.CompareTo(right) >= 0;

    public bool Equals(Option<T> other) =>
        (!IsSome && !other.IsSome) ||
        (IsSome && other.IsSome && EqualityComparer<T>.Default.Equals(Value, other.Value));

    public override bool Equals(object obj) => obj is Option<T> option && Equals(option);

    public override int GetHashCode() => IsSome ? _value.GetHashCode() : 0;

    public int CompareTo(Option<T> other)
    {
        if (IsSome && !other.IsSome)
        {
            return 1;
        }

        if (!IsSome && !other.IsSome)
        {
            return -1;
        }

        return Comparer<T>.Default.Compare(Value, other.Value);
    }

    public override string ToString() => IsSome ? $"Some ({Value})" : "None";

    public IEnumerable<T> ToEnumerable()
    {
        if (IsSome)
        {
            yield return Value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (IsSome)
        {
            yield return Value;
        }
    }

    public Option<TResult> Bind<TResult>(Func<T, Option<TResult>> mapping) =>
        mapping == null
            ? throw new ArgumentNullException(nameof(mapping))
            : Match(mapping, None<TResult>);

    public bool Contains(T value) => IsSome && Value.Equals(value);

    public bool Exists(Func<T, bool> predicate) => predicate == null
        ? throw new ArgumentNullException(nameof(predicate))
        : IsSome && predicate(Value);

    public Option<T> Filter(Func<T, bool> predicate)
    {
        return predicate == null ? throw new ArgumentNullException(nameof(predicate)) :
            IsSome && !predicate(Value) ? None<T>() : this;
    }

    public Option<TResult> Map<TResult>(Func<T, TResult> mapping) =>
        mapping == null
            ? throw new ArgumentNullException(nameof(mapping))
            : Match(value => Some(mapping(value)), None<TResult>);

    public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none) =>
        some == null ? throw new ArgumentNullException(nameof(some)) :
        none == null ? throw new ArgumentNullException(nameof(none)) :
        IsSome ? some(Value) : none();
}