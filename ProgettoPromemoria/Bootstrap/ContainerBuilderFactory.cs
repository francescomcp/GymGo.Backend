namespace ProgettoPromemoria.Bootstrap;

using Autofac;
using ProgettoPromemoria.Configuration;

public static class ContainerBuilderFactory
{
    public static ContainerBuilder Create(this ContainerBuilder containerBuilder, MongoConfiguration configuration)
    {
        containerBuilder.RegisterModule(new MemoModule());
        containerBuilder.RegisterModule(new UserModule());
        containerBuilder.RegisterModule(new MongoDBModule(configuration));
        return containerBuilder;
    }
}
