using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;

namespace BeautySalon.Application.IRepositories;

public interface IServicesRepository
{
    ValueTask<PrimitiveResult<MainService[]>> GetMainServices(CancellationToken cancellationToken);
    ValueTask<PrimitiveResult<Subservice[]>> GetSubServices(int mainServiceId, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<MainService>> AddMainService(MainService entity, CancellationToken cancellationToken);
    ValueTask<PrimitiveResult<Subservice>> AddSubService(Subservice entity, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<MainService>> UpdateMainService(MainService entity, CancellationToken cancellationToken);
    ValueTask<PrimitiveResult<Subservice>> UpdateSubservice(Subservice entity, CancellationToken cancellationToken);

    ValueTask<PrimitiveResult<MainService>> DeleteMainService(MainService entity, CancellationToken cancellationToken);
    ValueTask<PrimitiveResult<Subservice>> DeleteSubservice(Subservice entity, CancellationToken cancellationToken);


}