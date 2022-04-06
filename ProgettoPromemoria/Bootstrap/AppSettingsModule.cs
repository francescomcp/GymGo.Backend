using Autofac;
using GymGo.Core.Helpers;

namespace GymGo.Bootstrap;

public class AppSettingsModule : Module
{
    private AppSettings _appSettings;
    public AppSettingsModule(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register<AppSettings>(x => _appSettings).SingleInstance();
    }
}
