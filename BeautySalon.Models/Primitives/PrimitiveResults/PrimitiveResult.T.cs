using BeautySalon.InfraStructure.Primitives.PrimitiveResults;

namespace BeautySalon.Models.Primitives.PrimitiveResults;

public readonly partial record struct PrimitiveResult<TValue>
{
    private TValue? _value { get; }

    public readonly TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("the value of failure result can not be accessed.");

    public readonly bool IsSuccess { get; }
    public readonly bool IsFailure => !IsSuccess;
    public readonly PrimitiveError[] Errors { get; }
    public PrimitiveError Error => Errors.Any()
        ? Errors[0]
        : throw new InvalidOperationException("empty error.");

    internal PrimitiveResult(TValue? value, bool isSuccess, PrimitiveError[] errors)
    {
        _value = value;
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static PrimitiveResult<TValue> Failure(PrimitiveError[] errors) => PrimitiveResult.Failure<TValue>(errors);

    public static PrimitiveResult From(PrimitiveResult<TValue> src) =>
      src.IsSuccess
      ? PrimitiveResult.Success()
      : PrimitiveResult.Failure(src.Errors);

    public static implicit operator PrimitiveResult<TValue>(TValue value) => PrimitiveResult.Success(value);
}
