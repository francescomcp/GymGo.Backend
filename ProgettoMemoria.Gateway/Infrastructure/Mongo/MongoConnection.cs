using MongoDB.Driver;

namespace ProgettoPromemoria.Gateway.Infrastructure.Mongo
{
    public class MongoConnection : IConnectionFactory
    {
        private string _connectionString { get; }
        private string _databaseName { get; }

        public MongoConnection(string connectionString, string databaseName)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;
        }
        public IMongoDatabase GetReadyConnectionAsync()
        {
            var mongoClient = new MongoClient(_connectionString);
            var mongoDatabase = mongoClient.GetDatabase(_databaseName);
            return mongoDatabase;
        }
    }
}
