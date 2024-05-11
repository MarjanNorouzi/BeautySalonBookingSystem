using BeautySalon.Application.IRepositories;
using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using BeautySalon.InfraStructure.Contexts;

namespace BeautySalon.InfraStructure.Repositories
{
    public sealed class SubServiceRepository : Repository<Subservice>, ISubServiceRepository
    {
        public SubServiceRepository(BeautySalonContext dbContext) : base(dbContext)
        {
        }

        public ValueTask<PrimitiveResult<Subservice>> AddSubService(Subservice entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PrimitiveResult<bool>> DeleteSubservice(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PrimitiveResult<IEnumerable<Subservice>>> GetSubServices(int mainServiceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PrimitiveResult<Subservice>> UpdateSubservice(Subservice entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
