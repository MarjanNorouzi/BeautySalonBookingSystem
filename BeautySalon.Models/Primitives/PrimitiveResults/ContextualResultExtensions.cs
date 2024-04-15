namespace BeautySalon.Models.Primitives.PrimitiveResults;
public static partial class ContextualResultExtensions
{
    public static ValueTask<ContextualResult<TContext>> Execute<TContext>(this ContextualResult<TContext> src, Func<TContext, TContext> func) => ContextualResult<TContext>.Execute(src, func);
    public static ValueTask<ContextualResult<TContext>> Execute<TContext>(this ContextualResult<TContext> src, Func<TContext, PrimitiveResult<TContext>> func) => ContextualResult<TContext>.Execute(src, func);
    public static ValueTask<ContextualResult<TContext>> Execute<TContext>(this ContextualResult<TContext> src, Func<TContext, ValueTask<PrimitiveResult<TContext>>> func) => ContextualResult<TContext>.Execute(src, func);
    public static ValueTask<ContextualResult<TContext>> Execute<TContext>(this ContextualResult<TContext> src, Func<TContext, Task<PrimitiveResult<TContext>>> func) => ContextualResult<TContext>.Execute(src, func);

    public static ValueTask<ContextualResult<TContext>> Execute<TContext>(this ValueTask<ContextualResult<TContext>> src, Func<TContext, TContext> func) => ContextualResult<TContext>.Execute(src, func);
    public static ValueTask<ContextualResult<TContext>> Execute<TContext>(this ValueTask<ContextualResult<TContext>> src, Func<TContext, PrimitiveResult<TContext>> func) => ContextualResult<TContext>.Execute(src, func);
    public static ValueTask<ContextualResult<TContext>> Execute<TContext>(this ValueTask<ContextualResult<TContext>> src, Func<TContext, ValueTask<PrimitiveResult<TContext>>> func) => ContextualResult<TContext>.Execute(src, func);
    public static ValueTask<ContextualResult<TContext>> Execute<TContext>(this ValueTask<ContextualResult<TContext>> src, Func<TContext, Task<PrimitiveResult<TContext>>> func) => ContextualResult<TContext>.Execute(src, func);

    public static ValueTask<PrimitiveResult<TOut>> Map<TContext, TOut>(this ContextualResult<TContext> src, Func<TContext, PrimitiveResult<TOut>> mapper) => ContextualResult<TContext>.Map(src, mapper);
    public static ValueTask<PrimitiveResult<TOut>> Map<TContext, TOut>(this ContextualResult<TContext> src, Func<TContext, TOut> mapper) => ContextualResult<TContext>.Map(src, mapper);
    public static ValueTask<PrimitiveResult<TOut>> Map<TContext, TOut>(this ValueTask<ContextualResult<TContext>> src, Func<TContext, PrimitiveResult<TOut>> mapper) => ContextualResult<TContext>.Map(src, mapper);
    public static ValueTask<PrimitiveResult<TOut>> Map<TContext, TOut>(this ValueTask<ContextualResult<TContext>> src, Func<TContext, TOut> mapper) => ContextualResult<TContext>.Map(src, mapper);
}