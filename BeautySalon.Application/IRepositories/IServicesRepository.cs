using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;

namespace BeautySalon.Application.IRepositories;

public interface IServicesRepository
{
    ValueTask<PrimitiveResult<IEnumerable<MainService>>> GetMainServices(CancellationToken cancellationToken);
    ValueTask<PrimitiveResult<IEnumerable<Subservice>>> GetSubServices(int mainServiceId, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<MainService>> AddMainService(MainService entity, CancellationToken cancellationToken);
    ValueTask<PrimitiveResult<Subservice>> AddSubService(Subservice entity, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<MainService>> UpdateMainService(MainService entity, CancellationToken cancellationToken);
    ValueTask<PrimitiveResult<Subservice>> UpdateSubservice(Subservice entity, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<bool>> DeleteMainService(int id, CancellationToken cancellationToken);
    ValueTask<PrimitiveResult<bool>> DeleteSubservice(int id, CancellationToken cancellationToken);
}
