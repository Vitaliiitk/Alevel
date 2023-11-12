
namespace VegetableSalad.Services.Abstraction
{
    internal interface ICreatePlant
    {
        public string PlantType {  get; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Taste { get; set; }
        public ushort CaloriesPerGram { get; set; }
    }
}
