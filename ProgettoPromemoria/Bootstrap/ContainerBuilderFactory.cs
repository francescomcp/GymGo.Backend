namespace ProgettoPromemoria.Bootstrap;

using Autofac;
using ProgettoPromemoria.Configuration;

public static class ContainerBuilderFactory
{
    public static ContainerBuilder Create(this ContainerBuilder containerBuilder, MongoConfiguration configuration)
    {
        containerBuilder.RegisterModule(new MemoModule(configuration));
        return containerBuilder;
    }
}
