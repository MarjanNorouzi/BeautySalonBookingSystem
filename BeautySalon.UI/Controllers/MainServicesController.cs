using BeautySalon.Application.Features.MainServiceFeatures.AddMainService;
using BeautySalon.Application.Features.MainServiceFeatures.GetMainServicesList;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MainServicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MainServicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> Get([FromQuery] GetMainServicesListRequest request, CancellationToken cancellationToken)
    {
        return await this._mediator.Send(request, cancellationToken)
            .Match(this.Ok,
                    onFailure => Problem(string.Join(',', onFailure.Select(x => x.Message))))
             .ConfigureAwait(false);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromQuery] AddMainServiceRequest request, CancellationToken cancellationToken)
    {
        return await this._mediator.Send(request, cancellationToken)
            .Match(this.Ok,
                    onFailure => Problem(string.Join(',', onFailure.Select(x => x.Message))))
             .ConfigureAwait(false);
    }

    //[HttpDelete("Delete")]
    //public async Task<IActionResult> Delete([FromQuery] AddMainServiceRequest request, CancellationToken cancellationToken)
    //{
    //    return await this._mediator.Send(request, cancellationToken)
    //        .Match(this.Ok,
    //                onFailure => Problem(string.Join(',', onFailure.Select(x => x.Message))))
    //         .ConfigureAwait(false);
    //}
}