using Microsoft.AspNetCore.Identity;

namespace BeautySalon.Domain.Entities.IdentityModels
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            ApplicationUserRoles = [];
        }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
