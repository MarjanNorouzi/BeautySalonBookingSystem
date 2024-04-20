using BeautySalon.Application.IRepositories;
using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveMaybies;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using BeautySalon.InfraStructure.Primitives.PrimitiveResults;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.InfraStructure.Repository
{
    public abstract class MyGenericRepository<TDbContext>
        where TDbContext : DbContext
    {
        protected readonly TDbContext _context;

        protected MyGenericRepository(TDbContext context)
        {
            _context = context;
        }

        public ValueTask<PrimitiveResult<T>> AddEntity<T>(T entity) where T : class => this.BeginTrackEntity(entity, e => this._context.Set<T>().Add(e));
        public ValueTask<PrimitiveResult<T>> UpdateEntity<T>(T entity) where T : class => this.BeginTrackEntity(entity, e => this._context.Set<T>().Update(e));

        public ValueTask<PrimitiveResult<T>> BeginTrackEntity<T>(T entity, Func<T, EntityEntry<T>> func) where T : class
        {
            var dbResult = func.Invoke(entity);

            return
                ValueTask.FromResult(
                    PrimitiveMaybe
                    .From(dbResult)
                    .Map(e => PrimitiveMaybe.From(e.Entity))
                    .Map(e => PrimitiveMaybe.From(PrimitiveResult.Success(e)))
                    .Map(e => {
                        var saveResult = this._context.SaveChanges();
                        return PrimitiveMaybe.From(saveResult > 0 ? e : null);
                    })
                    .GetOr(PrimitiveResult.Failure<T>("", "Error!")));
        }
    }

    public sealed class ServicesRepository : IServicesRepository
    {
        public ValueTask<PrimitiveResult<MainService>> AddMainService(MainService entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PrimitiveResult<Subservice>> AddSubService(Subservice entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PrimitiveResult<bool>> DeleteMainService(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PrimitiveResult<bool>> DeleteSubservice(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PrimitiveResult<IEnumerable<MainService>>> GetMainServices(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PrimitiveResult<IEnumerable<Subservice>>> GetSubServices(int mainServiceId, CancellationToken cancellationToken)
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
}
