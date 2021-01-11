namespace Infrastructure.Context
{
    public class AirBnbContext : IAirBnbContext
    {
        public string ConnectionString { get;set; }
        public string DatabaseName { get;set; }
    }
    public interface IAirBnbContext 
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    

}
