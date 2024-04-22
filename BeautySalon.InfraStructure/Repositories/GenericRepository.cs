using BeautySalon.Domain.Primitives.PrimitiveMaybies;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using BeautySalon.InfraStructure.Primitives.PrimitiveResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BeautySalon.InfraStructure.Repositories;

public abstract class GenericRepository<TDbContext>
    where TDbContext : DbContext
{
    protected readonly TDbContext _context;

    protected GenericRepository(TDbContext context)
    {
        _context = context;
    }

    public ValueTask<PrimitiveResult<TEntity>> AddEntity<TEntity>(TEntity entity) where TEntity : class =>
        BeginTrackEntity(this._context.Set<TEntity>().Add(entity), PrimitiveError.Create("", "Add failed!"));

    public ValueTask<PrimitiveResult<TEntity>> UpdateEntity<TEntity>(TEntity entity) where TEntity : class =>
        BeginTrackEntity(this._context.Set<TEntity>().Update(entity), PrimitiveError.Create("", "Update failed!"));

    public ValueTask<PrimitiveResult<TEntity>> DeleteEntity<TEntity>(TEntity entity) where TEntity : class =>
         BeginTrackEntity(this._context.Set<TEntity>().Remove(entity), PrimitiveError.Create("", "Delete failed!"));

    private ValueTask<PrimitiveResult<TEntity>> BeginTrackEntity<TEntity>(EntityEntry<TEntity> entryEntity, PrimitiveError primitiveError) where TEntity : class =>
         ValueTask.FromResult(
                PrimitiveMaybe
                .From(entryEntity)
                .Map(e => PrimitiveMaybe.From(e.Entity))
                .Map(e => PrimitiveMaybe.From(PrimitiveResult.Success(e)))
                .Map(e =>
                {
                    var saveChanges = this._context.SaveChanges();
                    return PrimitiveMaybe.From(saveChanges > 0 ? e : null);
                })
                .GetOr(PrimitiveResult.Failure<TEntity>(primitiveError)));
}