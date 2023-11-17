using ElectricalAppliances.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalAppliances.Services.Abstractions
{
    internal interface IDeviceService
    {
        public List<ElectricalDevice> AddDevice(string deviceType, string name, double weight, double powerConsumption);
        public double CalculateConsumption();
        public List<ElectricalDevice> SortDeviceByConsumtion();
        public List<ElectricalDevice> FindAllIndustrial();
    }

}
