using BeautySalon.Application.DI;
using BeautySalon.InfraStructure.ConnectionStrings;
using BeautySalon.InfraStructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BeautySalon.InfraStructure.DI;

public static class ApplicationInstaller
{
    public static IServiceCollection InstallInfrastructure(this IServiceCollection services)
    {
        return services
            .InstallApplication()
            .InstallPersistence();
    }

    public static IServiceCollection InstallPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BeautySalonContext>(options =>
            options.UseSqlServer(ConnectionString.BeautySalonConnectionString)
        );

        services.AddDbContext<BeautySalonContext>(options =>
            options
                .UseSqlServer(ConnectionString.BeautySalonConnectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
        );

        //services.AddScoped<ICodingRepository, CodingRepository>();

        return services;
    }
}