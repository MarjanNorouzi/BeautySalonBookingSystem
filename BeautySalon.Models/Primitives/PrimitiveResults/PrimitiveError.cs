namespace BeautySalon.Domain.Primitives.PrimitiveResults;

public readonly record struct PrimitiveError
{
    internal readonly static PrimitiveError NoError = Create(string.Empty, string.Empty);
    internal readonly static PrimitiveError[] NoErrorArray = new PrimitiveError[1] { Create(string.Empty, string.Empty) };

    public readonly string Code { get; }
    public readonly string Message { get; }
    public readonly bool Internal { get; }
    public Exception? Exception { get; }
    public int? Status { get; }

    private PrimitiveError(string code, string message, bool isInternal, Exception? ex, int? status)
    {
        Code = code;
        Message = message;
        Internal = isInternal;
        Exception = ex;
        Status = status;
    }
    private static PrimitiveError CreateCore(string code, string message, bool isInternal, Exception? ex = null, int? status = null) => new PrimitiveError(code, message, isInternal, ex, status);

    public static PrimitiveError Create(string code, string message) => CreateCore(code, message, false);
    public static PrimitiveError Create(string code, string message, int status) => CreateCore(code, message, false, status: status);
    public static PrimitiveError CreateInternal(string code, string message) => CreateCore(code, message, true);
    public static PrimitiveError CreateInternal(string code, string message, int status) => CreateCore(code, message, true, status: status);
    public static PrimitiveError CreateException(string code, Exception exception) => CreateCore(code, exception.Message, false, exception, 500);
    public static PrimitiveError CreateException(string code, Exception exception, int status) => CreateCore(code, exception.Message, false, exception, status);
    public static PrimitiveError CreateException(string code, string message, Exception exception, int status) => CreateCore(code, message, false, exception, status);
    public static PrimitiveError CreateInternalException(string code, Exception exception) => CreateCore(code, exception.Message, true, exception, 500);
    public static PrimitiveError CreateInternalException(string code, Exception exception, int status) => CreateCore(code, exception.Message, true, exception, status);
    public static PrimitiveError CreateInternalException(string code, string message, Exception exception, int status) => CreateCore(code, message, true, exception, status);


    internal static bool HasError(PrimitiveError? error) => error?.Equals(NoError) ?? false;
    internal static bool HasError(PrimitiveError[] errors) => errors?.Equals(NoErrorArray) ?? false;
}
