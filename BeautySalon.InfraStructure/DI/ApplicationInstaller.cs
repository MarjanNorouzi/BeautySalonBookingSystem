using BeautySalon.Application.DI;
using BeautySalon.Application.IRepositories;
using BeautySalon.InfraStructure.ConnectionStrings;
using BeautySalon.InfraStructure.Contexts;
using BeautySalon.InfraStructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BeautySalon.InfraStructure.DI;

public static class ApplicationInstaller
{
    public static IServiceCollection InstallInfrastructure(this IServiceCollection services)
    {
        return services
            .InstallApplication()
            .InstallPersistance()
            .AddBeautySalonServices();
    }


    public static IServiceCollection AddBeautySalonServices(this IServiceCollection services)
    {
        services.AddScoped<IServicesRepository, ServicesRepository>();

        return services;
    }

    public static IServiceCollection InstallPersistance(this IServiceCollection services)
    {
        services.AddDbContext<BeautySalonContext>(options => options.UseSqlServer(ConnectionString.BeautySalonConnectionString));

        services.AddDbContext<BeautySalonContext>(options =>
            options
                .UseSqlServer(ConnectionString.BeautySalonConnectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        );

        return services;
    }
}