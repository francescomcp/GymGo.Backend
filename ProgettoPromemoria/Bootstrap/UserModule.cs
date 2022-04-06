using Autofac;
using GymGo.Gateway.Repositories;
using GymGo.Core.Services;

namespace GymGo.Bootstrap;

public class UserModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserService>().As<IUserService>();
        builder.RegisterType<UserRepository>().As<IUserRepository>();
    }
}
