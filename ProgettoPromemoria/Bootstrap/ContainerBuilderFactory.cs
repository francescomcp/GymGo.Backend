namespace GymGo.Bootstrap;

using Autofac;
using GymGo.Configuration;
using GymGo.Core.Helpers;

public static class ContainerBuilderFactory
{
    public static ContainerBuilder Create(this ContainerBuilder containerBuilder, MongoConfiguration configuration, AppSettings appSettings)
    {
        containerBuilder.RegisterModule(new MemoModule());
        containerBuilder.RegisterModule(new UserModule());
        containerBuilder.RegisterModule(new MongoDBModule(configuration));
        containerBuilder.RegisterModule(new AppSettingsModule(appSettings));
        return containerBuilder;
    }
}
