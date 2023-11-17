using ElectricalAppliances;
using ElectricalAppliances.Repositories;
using ElectricalAppliances.Repositories.Abstractions;
using ElectricalAppliances.Services;
using ElectricalAppliances.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;



    var serviceCollection = new ServiceCollection()
    .AddTransient<IDeviceService, DeviceService>()
    .AddTransient<IRepository, Repository>()
    .AddTransient<App>();

    var provider = serviceCollection.BuildServiceProvider();

    var app = provider.GetService<App>();
    app!.Start();
