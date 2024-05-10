using BeautySalon.InfraStructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace BeautySalon.InfraStructure.Repositories;

//public abstract class GenericRepository<TDbContext>
//    where TDbContext : DbContext
//{
//    protected readonly TDbContext _context;

//    protected GenericRepository(TDbContext context)
//    {
//        _context = context;
//    }

//    public ValueTask<PrimitiveResult<TEntity>> AddEntity<TEntity>(TEntity entity) where TEntity : class =>
//        BeginTrackEntity(this._context.Set<TEntity>().Add(entity), PrimitiveError.Create("", "Add failed!"));

//    public ValueTask<PrimitiveResult<TEntity>> UpdateEntity<TEntity>(TEntity entity) where TEntity : class =>
//        BeginTrackEntity(this._context.Set<TEntity>().Update(entity), PrimitiveError.Create("", "Update failed!"));

//    public ValueTask<PrimitiveResult<TEntity>> DeleteEntity<TEntity>(TEntity entity) where TEntity : class =>
//         BeginTrackEntity(this._context.Set<TEntity>().Remove(entity), PrimitiveError.Create("", "Delete failed!"));

//    private ValueTask<PrimitiveResult<TEntity>> BeginTrackEntity<TEntity>(EntityEntry<TEntity> entryEntity, PrimitiveError primitiveError) where TEntity : class =>
//         ValueTask.FromResult(
//                PrimitiveMaybe
//                .From(entryEntity)
//                .Map(e => PrimitiveMaybe.From(e.Entity))
//                .Map(e => PrimitiveMaybe.From(PrimitiveResult.Success(e)))
//                .Map(e =>
//                {
//                    var saveChanges = this._context.SaveChanges();
//                    return PrimitiveMaybe.From(saveChanges > 0 ? e : null);
//                })
//                .GetOr(PrimitiveResult.Failure<TEntity>(primitiveError)));
//}


public class GenericRepository2<TEntity, TDbContext>
where TDbContext : DbContext
{
    internal BeautySalonContext context;
    //internal DbSet<TEntity> dbSet;

    public GenericRepository2(BeautySalonContext context)
    {
        this.context = context;
        //this.dbSet = context.Set<TEntity>();
    }

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
            return [.. orderBy(query)];
        }
        else
        {
            return [.. query];
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

public class GenericRepository<TEntity, TContext> /* :IGenericRepository<TEntity>*/ where TEntity : class
                                                                                   where TContext : DbContext
{
    private readonly TContext _context;
    //private readonly PascalTransaction _pascalTransaction;
    private readonly DbSet<TEntity> _dbSet;
    private readonly CancellationToken _cancellationToken;

    public GenericRepository(TContext context, CancellationToken cancellationToken)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
        //this._pascalTransaction = pascalTransaction;
        _cancellationToken = cancellationToken;
    }

    public virtual IQueryable<TEntity> GetAll(bool asNoTracking = true)
    {
        if (asNoTracking)
        {
            return _dbSet.AsNoTracking();
        }
        return _dbSet;
    }

    public virtual async ValueTask<TEntity?> GetByIDAsync(object id)
    {
        return await _dbSet.FindAsync([id], _cancellationToken);
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity, _cancellationToken);
    }

    public virtual async Task InsertMultipleAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities, _cancellationToken);
    }

    //public virtual async Task<int> InsertMultipleAsync<TSource>(IQueryable<TSource> source, Expression<Func<TSource, TEntity>> setter)
    //{
    //    await _pascalTransaction.SetTransaction(_cancellationToken);
    //    var affectedRows = await source.InsertAsync(_dbSet.ToLinqToDBTable(), setter, _cancellationToken);
    //    await _pascalTransaction.IncreaseAffectedRowsInTrans(affectedRows, _cancellationToken);
    //    return affectedRows;
    //}

    public virtual async Task DeleteMultipleAsync(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            Delete(entity);
        }
    }

    //public virtual async Task<int> DeleteMultipleAsync<TSource>(IQueryable<TSource> source)
    //{
    //    await _pascalTransaction.SetTransaction(_cancellationToken);
    //    var affectedRows = await source.ToLinqToDB().DeleteAsync(_cancellationToken);
    //    await _pascalTransaction.IncreaseAffectedRowsInTrans(affectedRows, _cancellationToken);
    //    return affectedRows;
    //}

    public virtual async Task DeleteAsync(object id)
    {
        TEntity entityToDelete = await _dbSet.FindAsync(id, _cancellationToken);
        if (entityToDelete != null)
        {
            Delete(entityToDelete);
        }
    }

    //public virtual async Task<int> DeleteAsync(object id)
    //{
    //    await _pascalTransaction.SetTransaction(_cancellationToken);
    //    var affectedRows = await _dbSet.DeleteByKeyAsync(_cancellationToken, id);
    //    await _pascalTransaction.IncreaseAffectedRowsInTrans(affectedRows, _cancellationToken);
    //    return affectedRows;
    //}

    public virtual void Delete(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }

    //public virtual async Task<int> UpdateMultipleAsync<TSource>(IQueryable<TSource> source, Expression<Func<TSource, TEntity>> setter)
    //{
    //    await _pascalTransaction.SetTransaction(_cancellationToken);
    //    var affectedRows = await source.UpdateAsync(_dbSet.ToLinqToDBTable(), setter, _cancellationToken);
    //    await _pascalTransaction.IncreaseAffectedRowsInTrans(affectedRows, _cancellationToken);
    //    return affectedRows;
    //}

    public virtual void Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    /// <summary>فقط وقتی یک رکورد بود از این استفاده شود</summary>
    //public virtual async Task<bool> PartialUpdateAsync(Expression<Func<TEntity>> partialUpdate)
    //{
    //    var result = partialUpdate.Compile().Invoke();
    //    var entry = _context.Entry(result);
    //    if (entry.State == EntityState.Deleted)
    //    {
    //        return false;
    //    }

    //    var expressionBody = partialUpdate.Body;

    //    if (expressionBody is UnaryExpression expression && expression.NodeType == ExpressionType.Convert)
    //    {
    //        expressionBody = expression.Operand;
    //    }
    //    var memberSelectorExpression = expressionBody as MemberInitExpression;

    //    var keyNames = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select(x => x.Name).ToList();
    //    var membersToModified = memberSelectorExpression.Bindings.Select(b => b.Member.Name);

    //    // یعنی اینکه کلیدهای اصلی مشخص نشده اند
    //    if (!membersToModified.Any(x => keyNames.Contains(x)))
    //    {
    //        throw new ArgumentException("کلید اصلی مشخص نشده است");
    //    }

    //    var membersWhereNotKeys = membersToModified.Where(b => !keyNames.Contains(b));

    //    var resultType = result.GetType();
    //    var candidate = true;

    //    foreach (var item in _dbSet.Local.Where(x => x.GetType() == resultType))
    //    {
    //        foreach (var keyName in keyNames)
    //        {
    //            if (!resultType.GetProperty(keyName).GetValue(item).Equals(resultType.GetProperty(keyName).GetValue(result)))
    //            {
    //                candidate = false;
    //                break;
    //            }
    //        }

    //        if (candidate)
    //        {
    //            foreach (var member in membersWhereNotKeys)
    //            {
    //                resultType.GetProperty(member).SetValue(item, resultType.GetProperty(member).GetValue(result));
    //            }
    //            //result.ModificationDate = DateTimeOffset.Now;
    //            return true;
    //        }
    //    }

    //    _dbSet.Attach(result);

    //    foreach (var p in membersWhereNotKeys)
    //    {
    //        entry.Property(p).IsModified = true;
    //    }
    //    //result.ModificationDate = DateTimeOffset.Now;
    //    //entry.Property(x => x.ModificationDate).IsModified = true;

    //    await _pascalTransaction.IncreaseAffectedRowsInTrans(1, _cancellationToken);
    //    return true;
    //}

}
