using BeautySalon.Domain.Primitives.PrimitiveMaybies;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using BeautySalon.InfraStructure.Contexts;
using BeautySalon.InfraStructure.Primitives.PrimitiveResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Linq.Expressions;

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


public class GenericRepository2<TDbContext>
where TDbContext : DbContext
{
    internal BeautySalonContext context;
    //internal DbSet<TEntity> dbSet;

    public GenericRepository2(BeautySalonContext context)
    {
        this.context = context;
        //this.dbSet = context.Set<TEntity>();
    }
    //public ValueTask<PrimitiveResult<TEntity>> AddEntity<TEntity>(TEntity entity) where TEntity : class =>
    //   BeginTrackEntity(this._context.Set<TEntity>().Add(entity), PrimitiveError.Create("", "Add failed!"));

    //public ValueTask<PrimitiveResult<TEntity>> UpdateEntity<TEntity>(TEntity entity) where TEntity : class =>
    //    BeginTrackEntity(this._context.Set<TEntity>().Update(entity), PrimitiveError.Create("", "Update failed!"));


    public virtual IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : class
    {
        IQueryable<TEntity> query = context.Set<TEntity>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    public virtual TEntity GetByID<TEntity>(object id) where TEntity : class
    {
        return context.Set<TEntity>().Find(id);
    }

    public virtual void Insert<TEntity>(TEntity entity) where TEntity : class
    {
        context.Set<TEntity>().Add(entity);
    }

    public virtual void Delete<TEntity>(object id) where TEntity : class
    {
        TEntity entityToDelete = context.Set<TEntity>().Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete<TEntity>(TEntity entityToDelete) where TEntity : class
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            context.Set<TEntity>().Attach(entityToDelete);
        }
        context.Set<TEntity>().Remove(entityToDelete);
    }

    public virtual void Update<TEntity>(TEntity entityToUpdate) where TEntity : class
    {
        context.Set<TEntity>().Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}
