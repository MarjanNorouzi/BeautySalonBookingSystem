using BeautySalon.Application.IRepositories;
using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using BeautySalon.InfraStructure.Contexts;

namespace BeautySalon.InfraStructure.Repositories
{
    public sealed class MainServiceRepository : Repository<MainService>, IMainServiceRepository
    {
        public MainServiceRepository(BeautySalonContext dbContext) : base(dbContext)
        {
        }

        public async ValueTask<PrimitiveResult<MainService>> AddMainService(MainService entity, CancellationToken cancellationToken)
        {
            await AddAsync(entity, cancellationToken);
            return entity;
        }

        public ValueTask<PrimitiveResult<bool>> DeleteMainService(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
      
        public ValueTask<PrimitiveResult<IEnumerable<MainService>>> GetMainServices(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
       
        public ValueTask<PrimitiveResult<MainService>> UpdateMainService(MainService entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
