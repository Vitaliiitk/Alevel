
using VegetableSalad.Models;
using VegetableSalad.PlantRepositories;

namespace VegetableSalad.Services
{
    public class MakeSalad
    {
        public List<Plant> saladDish = new List<Plant>();

        public void Salad()
        {
            CreatePlant createPlant = new CreatePlant();
            PlantRepository ourSalad = new PlantRepository();
            do
            {
                createPlant.ParameterOfPlan();
                ourSalad.AddPlant(createPlant.PlantType, createPlant.Name, createPlant.Taste, createPlant.Weight, createPlant.CaloriesPerGram);
            } while (createPlant.Name != "stop");

            saladDish.AddRange(ourSalad.plantStorage);
        }

        public List<Plant> MySalad()
        {
            return saladDish;
        }
    }
}
