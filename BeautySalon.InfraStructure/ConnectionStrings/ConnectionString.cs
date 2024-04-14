namespace BeautySalon.InfraStructure.ConnectionStrings
{
    public record ConnectionString
    {
        public const string BeautySalonConnectionString = "data source=.; initial catalog=BeautySalon; TrustServerCertificate=true;MultipleActiveResultSets=true; integrated security=true;";
    }
}
