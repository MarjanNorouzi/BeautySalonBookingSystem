namespace BeautySalon.Models.Primitives.PrimitiveMaybies;

public readonly record struct PrimitiveMaybe
{
    public static PrimitiveMaybe<T> From<T>(T? value) => new PrimitiveMaybe<T>(value);

}
public readonly record struct PrimitiveMaybe<T>
{
    private readonly T? _value;

    internal PrimitiveMaybe(T? value) => _value = value;

    internal bool IsNull() => _value is null;
    internal T Value => _value is null
        ? throw new InvalidOperationException("Can not access a null value")
        : _value;
}

public static class PrimitiveMaybeExtensions
{
    public static PrimitiveMaybe<TOut> Map<T, TOut>(this PrimitiveMaybe<T> src, Func<T, PrimitiveMaybe<TOut>> mapper) =>
        src.IsNull() ? PrimitiveMaybe.From<TOut>(default) : mapper(src.Value);

    public static T GetOr<T>(this PrimitiveMaybe<T> src, T value)
        => src.IsNull() ? value : src.Value;
}