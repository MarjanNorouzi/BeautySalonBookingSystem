using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;

namespace BeautySalon.Application.IRepositories;

public interface ISubServiceRepository
{
    ValueTask<PrimitiveResult<IEnumerable<Subservice>>> GetSubServices(int mainServiceId, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<Subservice>> AddSubService(Subservice entity, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<Subservice>> UpdateSubservice(Subservice entity, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<bool>> DeleteSubservice(int id, CancellationToken cancellationToken);
}
