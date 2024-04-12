using Microsoft.AspNetCore.Identity;

namespace BeautySalon.Models.IdentityModels
{
    public class ApplicationRole : IdentityRole
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
