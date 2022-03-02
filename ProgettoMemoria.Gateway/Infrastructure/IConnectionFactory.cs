using MongoDB.Driver;

namespace ProgettoPromemoria.Gateway.Infrastructure;

public interface IConnectionFactory
{
    IMongoDatabase GetReadyConnectionAsync();
}
