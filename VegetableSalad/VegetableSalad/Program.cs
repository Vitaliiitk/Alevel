using VegetableSalad.PlantRepositories;
using VegetableSalad.PlantRepositories.Abstraction;
using VegetableSalad.Services;
using VegetableSalad.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace VegetableSalad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
            .AddTransient<App>();
            var provider = serviceCollection.BuildServiceProvider();
            var app = provider.GetService<App>();
            app!.Start();
        }
    }
}