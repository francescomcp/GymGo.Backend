using Autofac;
using GymGo.Configuration;
using GymGo.Gateway.Infrastructure;
using GymGo.Gateway.Infrastructure.Mongo;
using GymGo.Gateway.Repositories;
using GymGo.Core.Services;

namespace GymGo.Bootstrap;

public class MemoModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MemoService>().As<IMemoService>();
        builder.RegisterType<MemoRepository>().As<IMemoRepository>();
    }
}
