using BeautySalon.Application.IRepositories;
using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using BeautySalon.InfraStructure.Contexts;
using BeautySalon.InfraStructure.Primitives.PrimitiveResults;

namespace BeautySalon.InfraStructure.Repositories;

// موقع متد باید تصمیم بگیریم که انتیتی چیه
// چون مثل این سرویس گاهی نیاز داریم دو تا انتیتی تو یه سرویس استفاده کنیم
public sealed class ServicesRepository(BeautySalonContext context) : /*GenericRepository<BeautySalonContext>(context),*/ IServicesRepository
{
    //public ValueTask<PrimitiveResult<MainService>> AddMainService(MainService entity, CancellationToken cancellationToken) => AddEntity(entity);

    //public ValueTask<PrimitiveResult<Subservice>> AddSubService(Subservice entity, CancellationToken cancellationToken) => AddEntity(entity);

    //public ValueTask<PrimitiveResult<MainService>> DeleteMainService(MainService entity, CancellationToken cancellationToken) => DeleteEntity(entity);

    //public ValueTask<PrimitiveResult<Subservice>> DeleteSubservice(Subservice entity, CancellationToken cancellationToken) => DeleteEntity(entity);

    //public async ValueTask<PrimitiveResult<MainService[]>> GetMainServices(CancellationToken cancellationToken) =>
    // await this._context.MainService.Run(m => m.ToArrayAsync(cancellationToken)).ConfigureAwait(false);

    //public async ValueTask<PrimitiveResult<Subservice[]>> GetSubServices(int mainServiceId, CancellationToken cancellationToken) =>
    //     await this._context.Subservice.Run(m => m.ToArrayAsync(cancellationToken)).ConfigureAwait(false);

    //public ValueTask<PrimitiveResult<MainService>> UpdateMainService(MainService entity, CancellationToken cancellationToken) => UpdateEntity(entity);

    //public ValueTask<PrimitiveResult<Subservice>> UpdateSubservice(Subservice entity, CancellationToken cancellationToken) => UpdateEntity(entity);
    public ValueTask<PrimitiveResult<MainService>> AddMainService(MainService entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PrimitiveResult<Subservice>> AddSubService(Subservice entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PrimitiveResult<MainService>> DeleteMainService(MainService entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PrimitiveResult<Subservice>> DeleteSubservice(Subservice entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PrimitiveResult<MainService[]>> GetMainServices(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PrimitiveResult<Subservice[]>> GetSubServices(int mainServiceId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PrimitiveResult<MainService>> UpdateMainService(MainService entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PrimitiveResult<Subservice>> UpdateSubservice(Subservice entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public static class PrimitiveResultIQueryableExtensions
{
    const string _queryableResultIsNullErrorMessage = "Queryable result is null.";
    public static PrimitiveResult<T> Generate_Queryable_Result_Is_Null_Error<T>() => PrimitiveResult.InternalFailure<T>("GenericReadRepositoryErrors.Error", _queryableResultIsNullErrorMessage);


    public static async ValueTask<PrimitiveResult<TResult>> Run<TEntity, TResult>(this IQueryable<TEntity> queryable, Func<IQueryable<TEntity>, Task<TResult>> func)
    {
        var dbResult = await func.Invoke(queryable).ConfigureAwait(false);

        if (dbResult is null) return Generate_Queryable_Result_Is_Null_Error<TResult>();

        return PrimitiveResult.Success(dbResult);
    }

    public static async ValueTask<PrimitiveResult<TResult>> Run<TEntity, TResult>(this IQueryable<TEntity> queryable, Func<IQueryable<TEntity>, Task<TResult>> func, PrimitiveError error)
    {
        var dbResult = await func.Invoke(queryable).ConfigureAwait(false);

        if (dbResult is null) return PrimitiveResult.Failure<TResult>(error);

        return PrimitiveResult.Success(dbResult);
    }
}