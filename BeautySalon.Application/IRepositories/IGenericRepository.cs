using BeautySalon.Domain.Primitives.PrimitiveResults;

namespace BeautySalon.Application.IRepositories
{
    public interface IGenericRepository
    {
        public ValueTask<PrimitiveResult<TEntity>> AddEntity<TEntity>(TEntity entity) where TEntity : class;
        public ValueTask<PrimitiveResult<TEntity>> UpdateEntity<TEntity>(TEntity entity) where TEntity : class;
    }
}
