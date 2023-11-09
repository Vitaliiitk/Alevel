
using VegetableSalad.Models;
using VegetableSalad.PlantRepositories.Abstraction;

namespace VegetableSalad.PlantRepositories
{
    public class PlantRepository : IPlantRepository
    {
        public  List<Plant> plantStorage = new List<Plant>();
        private int plantCounter = 0;

        public void AddPlant(string plantType, string name, string taste, double weight, ushort caloriesPer100Gram)
        {
            Plant plant = new Plant()
            {
                PlantType = plantType,
                Name = name,
                Taste = taste,
                Weight = weight,
                CaloriesPerGram = caloriesPer100Gram
            };

            //plantStorage[plantCounter] = plant;
            if (plant.Name != "stop")
            {
                plantStorage.Add(plant);
                plantCounter++;
            }  
        }
    }
}
