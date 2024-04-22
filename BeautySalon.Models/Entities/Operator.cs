using BeautySalon.Domain.Entities.IdentityModels;

namespace BeautySalon.Domain.Entities
{
    public sealed class Operator : BaseEntity<int>
    {
        public Operator()
        {
            SubserviceOperators = [];
        }

        // این پراپرتی رو برای حالتی گذاشته بودم که نشون بدم اپراتور چه مهارت هایی داره و کارهایی رو میتونه انجام بده
        // که با کلید داشتن به جدول ساب سرویس مشخص میشه و نیازی به این پراپرتی نیست
        //public string Expertise { get; set; }

        public Guid UserId { get; set; }

        public required ApplicationUser ApplicationUser { get; set; }

        public required ICollection<SubserviceOperator> SubserviceOperators { get; set; }
    }
}