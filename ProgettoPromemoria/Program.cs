using Autofac;
using Autofac.Extensions.DependencyInjection;
using GymGo.Bootstrap;
using GymGo.Configuration;
using GymGo.Core.Helpers;

public static class Program
{

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(b => b.CreateContainer(builder.Configuration));
        builder.Services.AddControllers();

        var app = builder.Build();
        {
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.MapControllers();
        }
        app.Run();

    }

    public static ContainerBuilder CreateContainer(this ContainerBuilder containerBuilder, IConfiguration configuration)
    {
        var mongoConfiguration = new MongoConfiguration 
        { 
            ConnectionString = configuration.GetSection("MongoConnection").GetValue<string>("ConnectionString"),
            DatabaseName = configuration.GetSection("MongoConnection").GetValue<string>("DatabaseName")
        };

        var appSettings = new AppSettings
        {
            Secret = configuration.GetSection("AppSettings").GetValue<string>("Secret")
        };

        return containerBuilder.Create(mongoConfiguration, appSettings);
    }
}