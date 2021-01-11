using Infrastructure.Context;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class Repository
    {
        public MongoClient client { get; set; }
        public IMongoDatabase database { get; set; }
        public Repository(IAirBnbContext con)
        {
            client = new MongoClient(con.ConnectionString);
            database = client.GetDatabase(con.DatabaseName);
        }
    }
}
