using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using MediatR;

namespace BeautySalon.Application.Features.MainServiceFeatures.AddMainService;
public sealed record AddMainServiceRequest(string Name, string? Description = "") : IRequest<PrimitiveResult<MainService>>
{
}