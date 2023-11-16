using ElectricalAppliances.models;
using ElectricalAppliances.Repositories;
using ElectricalAppliances.Repositories.Abstractions;
using ElectricalAppliances.Services.Abstractions;

namespace ElectricalAppliances.Services
{
    internal class DeviceService : IDeviceService
    {

        private readonly IRepository _repository;

        public DeviceService(IRepository repository)
        {
            _repository = repository;

        }

        public List<ElectricalDevice> AddDevice(string deviceType, string name, double weight, double powerConsumption)
        {
            var device = _repository.AddDevice(deviceType, name, weight, powerConsumption);
            return device;
        }

        public double CalculateConsumption()
        {
            double consumption = _repository.CalculateConsumption();

            return consumption;
        }

        public List<ElectricalDevice> SortDeviceByConsumtion()
        {
            List<ElectricalDevice> sort = _repository.SortDeviceByConsumtion();

            return sort;
        }

        public List<ElectricalDevice> FindAllIndustrial()
        {
            List<ElectricalDevice> industrialOnly = _repository.FindAllIndustrial();

            
            return industrialOnly;
        }

    }
}
