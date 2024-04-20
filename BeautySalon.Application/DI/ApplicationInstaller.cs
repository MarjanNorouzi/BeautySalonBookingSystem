using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BeautySalon.Application.DI;

public static class ApplicationInstaller
{
    public static IServiceCollection InstallApplication(this IServiceCollection services)
    {
        return services
            .InstallMediatR()
            .InstallFLuentValidation();
    }

    public static IServiceCollection InstallMediatR(this IServiceCollection services)
    {
        return services.AddMediatR(cfg =>
        {

            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehaviour<,>));
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestLoggerBehaviour<,>));
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestDurationBehaviour<,>));
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidatorBehaviour<,>));
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(FluentValidationRequestValidatorBehaviour<,>));

            //cfg.AddBehavior(typeof(IRequestExceptionHandler<,,>), typeof(ValidationExceptionHandlerBehaviour<,,>));

            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());

        });
    }

    public static IServiceCollection InstallFLuentValidation(this IServiceCollection services)
    {
        return services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]));
    }
}