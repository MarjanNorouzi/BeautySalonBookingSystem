using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using MediatR;

namespace BeautySalon.Application.Features.MainServiceFeatures.GetMainServicesList;
internal class GetMainServicesListHandler : IRequestHandler<GetMainServicesListRequest, PrimitiveResult<MainService[]>>
{
    public Task<PrimitiveResult<MainService[]>> Handle(GetMainServicesListRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
