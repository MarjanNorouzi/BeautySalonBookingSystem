using Microsoft.AspNetCore.Identity;

namespace BeautySalon.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string userName) : base(userName)
        {
            ApplicationUserRoles = [];
        }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public Customer Customer { get; set; }

        public Operator Operator { get; set; }
    }
}
