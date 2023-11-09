using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.PlantRepositories.Abstraction
{
    public interface IPlantRepository
    {
        public void AddPlant(string plantType, string name, string taste, double weight, ushort caloriesPer100Gram);
    }
}
