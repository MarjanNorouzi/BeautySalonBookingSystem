using Microsoft.AspNetCore.Identity;

namespace BeautySalon.Models.IdentityModels
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Guid RoleId { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
