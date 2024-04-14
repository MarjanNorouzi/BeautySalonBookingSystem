using BeautySalon.InfraStructure.ConnectionStrings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeautySalon.InfraStructure.Contexts;
internal class BeautySalonContextFactory : IDesignTimeDbContextFactory<BeautySalonContext>
{
    public BeautySalonContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BeautySalonContext>();

        optionsBuilder.UseSqlServer(ConnectionString.BeautySalonConnectionString);
        return new BeautySalonContext(optionsBuilder.Options);
    }
}
