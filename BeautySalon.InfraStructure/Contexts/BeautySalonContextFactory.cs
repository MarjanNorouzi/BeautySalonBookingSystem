using BeautySalon.InfraStructure.ConnectionStrings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.InfraStructure.Contexts;
internal class BeautySalonContextFactory: IDesignTimeDbContextFactory<BeautySalonContext>
{
    public BeautySalonContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BeautySalonContext>();

        optionsBuilder.UseSqlServer(ConnectionString.BeautySalonConnectionString);
        return new BeautySalonContext(optionsBuilder.Options);
    }
}
