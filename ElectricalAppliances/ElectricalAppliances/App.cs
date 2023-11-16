using ElectricalAppliances.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalAppliances
{
    internal class App
    {
        private readonly IDeviceService _deviceService;

        public App(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        public void Start()
        {
            _deviceService.AddDevice("Home appliance", "laptop", 2.5, 200);
            _deviceService.AddDevice("Home appliance", "television set", 5, 120);
            _deviceService.AddDevice("Home appliance", "washing machine", 40, 1300);
            _deviceService.AddDevice("Home appliance", "microwave", 15, 1500);
            _deviceService.AddDevice("industrial appliance", "drill", 15, 1800);
            var ourDevices = _deviceService.AddDevice("industrial appliance", "welding machine", 12, 2000);

            foreach (var device in ourDevices)
            {
                Console.WriteLine($"We pluged in {device.Name} ");
            }

            double totalPlugedInConsumption = _deviceService.CalculateConsumption();
            Console.WriteLine($"total consumption of pluged in electrical devices is {totalPlugedInConsumption} watt");

            var sort = _deviceService.SortDeviceByConsumtion();
            Console.WriteLine($"From higher to lower :");

            foreach (var item in sort)
            {
                Console.Write($"{item.PowerConsumption}, ");
            }

            var allIndustryDevices = _deviceService.FindAllIndustrial();
            Console.WriteLine("\nAll Industry type devices are:");

            foreach (var device in allIndustryDevices)
            {
                Console.Write($"|{device.Name}| ");
            }

        }
    }
}
