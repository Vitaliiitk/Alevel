using ElectricalAppliances.models;
using ElectricalAppliances.Repositories.Abstractions;
using System.Linq;

namespace ElectricalAppliances.Repositories
{
    internal class Repository : IRepository
    {
        private readonly List<ElectricalDevice> plugIn = new List<ElectricalDevice>();
        private int deviceCounter = 0;

        public List<ElectricalDevice> AddDevice(string deviceType, string name, double weight, double powerConsumption)
        {
            ElectricalDevice device = new ElectricalDevice()
            {
                DeviceType = deviceType,
                Name = name,
                Weight = weight,
                PowerConsumption = powerConsumption
            };

            plugIn.Add(device);
            deviceCounter++;
            return plugIn;
        }

        public double CalculateConsumption()
        {
            double consumption = 0;
            foreach (var item in plugIn)
            {
                consumption = consumption + item.PowerConsumption;
            }
            return consumption;
        }

        public List<ElectricalDevice> SortDeviceByConsumtion()
        {
            List<ElectricalDevice> sortFromLeastPowerfulToMost = plugIn.OrderByDescending(x => x.PowerConsumption).ToList();
            return sortFromLeastPowerfulToMost;
        }

        public List<ElectricalDevice> FindAllIndustrial()
        {
            List<ElectricalDevice> industrialOnly = new List<ElectricalDevice>();

            foreach (var item in plugIn)
            {
                if (item.DeviceType.Contains("industrial"))
                {
                    industrialOnly.Add(item);
                }
            }
            return industrialOnly;
        }
    }
}
