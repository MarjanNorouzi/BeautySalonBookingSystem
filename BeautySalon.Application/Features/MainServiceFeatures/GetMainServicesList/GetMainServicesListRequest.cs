using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using MediatR;

namespace BeautySalon.Application.Features.MainServiceFeatures.GetMainServicesList;
public sealed record GetMainServicesListRequest : IRequest<PrimitiveResult<MainService[]>>
{
}
