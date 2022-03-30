using Autofac;
using ProgettoPromemoria.Configuration;
using ProgettoPromemoria.Gateway.Infrastructure;
using ProgettoPromemoria.Gateway.Infrastructure.Mongo;
using ProgettoPromemoria.Gateway.Repositories;
using ProgettoPromemoria.Core.Services;

namespace ProgettoPromemoria.Bootstrap
{
    public class UserModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
