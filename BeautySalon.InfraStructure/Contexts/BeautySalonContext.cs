using BeautySalon.InfraStructure.ConnectionStrings;
using BeautySalon.InfraStructure.Mapping;
using BeautySalon.Models;
using BeautySalon.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.InfraStructure.Contexts
{
    public class BeautySalonContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>,
        ApplicationUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public BeautySalonContext(DbContextOptions<BeautySalonContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Operator> Operator { get; set; }
        public DbSet<MainService> MainService { get; set; }
        public DbSet<Subservice> Subservice { get; set; }
        public DbSet<SubserviceOperator> SubserviceOperator { get; set; }
        public DbSet<Appointment> Appointment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.BeautySalonConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OperatorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MainServiceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubserviceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentEntityConfiguration());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasKey(x => x.Id);
            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.ApplicationUserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<ApplicationUser>().HasOne(x => x.Customer);
            modelBuilder.Entity<ApplicationUser>().HasOne(x => x.Operator);

            modelBuilder.Entity<ApplicationRole>().ToTable("AspNetRoles");
            modelBuilder.Entity<ApplicationRole>().HasKey(x => x.Id);
            modelBuilder.Entity<ApplicationRole>().HasMany(x => x.ApplicationUserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(x => x.User);
            modelBuilder.Entity<ApplicationUserRole>().HasOne(x => x.Role);

            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();

            GenerateRoleData(modelBuilder);
        }

        private static void GenerateRoleData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = Guid.Parse(RoleSeedData.UserId),
                    Name = RoleSeedData.UserName,
                    NormalizedName = RoleSeedData.UserNormalizedName,
                    ConcurrencyStamp = RoleSeedData.UserConcurrencyStamp
                },
                 new ApplicationRole
                 {
                     Id = Guid.Parse(RoleSeedData.OperatorId),
                     Name = RoleSeedData.OperatorName,
                     NormalizedName = RoleSeedData.OperatorNormalizedName,
                     ConcurrencyStamp = RoleSeedData.OperatorConcurrencyStamp
                 },
                new ApplicationRole
                {
                    Id = Guid.Parse(RoleSeedData.AdminId),
                    Name = RoleSeedData.AdminName,
                    NormalizedName = RoleSeedData.AdminNormalizedName,
                    ConcurrencyStamp = RoleSeedData.AdminConcurrencyStamp
                });
        }
    }
}