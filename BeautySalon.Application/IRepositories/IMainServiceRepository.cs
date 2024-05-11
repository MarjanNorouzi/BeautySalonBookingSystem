using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;

namespace BeautySalon.Application.IRepositories;

public interface IMainServiceRepository
{
    ValueTask<PrimitiveResult<IEnumerable<MainService>>> GetMainServices(CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<MainService>> AddMainService(MainService entity, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<MainService>> UpdateMainService(MainService entity, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<bool>> DeleteMainService(int id, CancellationToken cancellationToken);
}
