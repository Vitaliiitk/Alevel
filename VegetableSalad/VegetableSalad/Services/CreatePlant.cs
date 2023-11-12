
using VegetableSalad.Services.Abstraction;

namespace VegetableSalad.Services
{
    internal class CreatePlant : ICreatePlant
    {
        public string PlantType { get; } = "Vegetable";
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Taste { get; set; }
        public ushort CaloriesPerGram { get; set; }

        public void ParameterOfPlan()
        {
            Name = Console.ReadLine();
            Random rnd = new Random();

            if (Name == "cucumber")
            {
                Taste = "neutral";
                Weight = rnd.Next(50, 90);
                CaloriesPerGram = (ushort)(15);
            }
            else if (Name == "tomato")
            {
                Taste = "sour and sweet";
                Weight = rnd.Next(80, 150);
                CaloriesPerGram = (ushort)(20);
            }
            else if (Name == "green salad")
            {
                Taste = "neutral";
                Weight = rnd.Next(40, 50);
                CaloriesPerGram = (ushort)(17);
            }
            else if (Name == "paprika")
            {
                Taste = "sweet";
                Weight = rnd.Next(30, 80);
                CaloriesPerGram = (ushort)(27);
            }
            else if (Name != "stop")
            { throw new Exception("Invalid data input"); }
        }
    }
}
