using BeautySalon.Application.IRepositories;
using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalon.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MainServicesController : ControllerBase
{
    private readonly IMainServiceRepository _repository;

    public MainServicesController(IMainServiceRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async ValueTask<PrimitiveResult<MainService>> CreateAsync(MainService mainService, CancellationToken cancellationToken)
    {
        return await _repository.AddMainService(mainService, cancellationToken);
    }
}
