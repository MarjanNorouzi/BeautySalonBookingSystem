﻿using BeautySalon.Application.IRepositories;
using BeautySalon.Domain.Entities;
using BeautySalon.Domain.Primitives.PrimitiveResults;
using MediatR;

namespace BeautySalon.Application.Features.MainServiceFeatures.AddMainService;
internal sealed class AddMainServiceHandler : IRequestHandler<AddMainServiceRequest, PrimitiveResult<MainService>>
{
    private readonly IServicesRepository _servicesRepository;

    public AddMainServiceHandler(IServicesRepository servicesRepository)
    {
        _servicesRepository = servicesRepository;
    }

    public Task<PrimitiveResult<MainService>> Handle(AddMainServiceRequest request, CancellationToken cancellationToken)
    {
        //_servicesRepository.AddMainService(new MainService() 
        //{
        //    Name = request.Name,
        //    CreatedDate = DateTime.UtcNow,
        //    Description = request.Description,
        //    UpdatedDate = DateTime.UtcNow
        //});

        throw new NotImplementedException();
    }
}