using Autofac;
using GymGo.Configuration;
using GymGo.Gateway.Infrastructure;
using GymGo.Gateway.Infrastructure.Mongo;

namespace GymGo.Bootstrap;

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
