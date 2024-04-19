namespace BeautySalon.InfraStructure.Contexts
{
    public class RoleSeedData
    {
        // TODO
        // بهتره اسم کاربر عادیم یوزر باشه یا مشتری؟
        // Customer OR User? 

        public const string UserId = "9A039FB2-86D2-401D-BDF4-7C5D325C38B4";
        public const string UserName = "User";
        public const string UserNormalizedName = "USER";
        public const string UserConcurrencyStamp = "42b079e1-f854-4516-9e19-3976f995791d";

        public const string AdminId = "5209521B-738A-44DB-9771-FBB29D1A321A";
        public const string AdminName = "Admin";
        public const string AdminNormalizedName = "ADMIN";
        public const string AdminConcurrencyStamp = "4298b909-6511-4ca7-977a-c6d4629d854e";

        public const string OperatorId = "4AE3EEDA-C45F-4307-B749-50276BFC37E1";
        public const string OperatorName = "Operator";
        public const string OperatorNormalizedName = "OPERATOR";
        public const string OperatorConcurrencyStamp = "66630827-3a85-49bc-bb07-1d49f8cd5381";
    }
}
