using Autofac;
using ProgettoPromemoria.Configuration;
using ProgettoPromemoria.Gateway.Infrastructure;
using ProgettoPromemoria.Gateway.Infrastructure.Mongo;
using ProgettoPromemoria.Gateway.Repositories;
using ProgettoPromemoria.Core.Services;

namespace ProgettoPromemoria.Bootstrap;

public class MongoDBModule : Module
{
    private MongoConfiguration _configuration { get; set; }

    public MongoDBModule(MongoConfiguration configuration)
    {
        _configuration = configuration;
    }
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MongoConnection>().As<IConnectionFactory>()
            .WithParameter("connectionString", _configuration.ConnectionString)
            .WithParameter("databaseName", _configuration.DatabaseName);
    }
}
