using Microsoft.AspNetCore.Identity;

namespace BeautySalon.Models.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {

        }

        public ApplicationUser(string userName) : base(userName)
        {
            ApplicationUserRoles = [];
        }

        public int CustomerId { get; set; }

        public int OperatorId { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public Customer Customer { get; set; }

        public Operator Operator { get; set; }
    }
}
