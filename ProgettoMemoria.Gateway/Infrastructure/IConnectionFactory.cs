using MongoDB.Driver;

namespace GymGo.Gateway.Infrastructure;

public interface IConnectionFactory
{
    IMongoDatabase GetReadyConnectionAsync();
}
