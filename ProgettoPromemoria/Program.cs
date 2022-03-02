using Autofac;
using Autofac.Extensions.DependencyInjection;
using ProgettoPromemoria.Bootstrap;
using ProgettoPromemoria.Configuration;

public static class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(b => b.CreateContainer(builder.Configuration));
        builder.Services.AddControllers();

        var app = builder.Build();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    public static ContainerBuilder CreateContainer(this ContainerBuilder containerBuilder, IConfiguration configuration)
    {
        var mongoConfiguration = new MongoConfiguration { ConnectionString = configuration.GetSection("MongoConnection").GetValue<string>("ConnectionString"),
            DatabaseName = configuration.GetSection("MongoConnection").GetValue<string>("DatabaseName")
        };

        return containerBuilder.Create(mongoConfiguration);
    }
}