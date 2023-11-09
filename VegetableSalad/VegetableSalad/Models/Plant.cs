using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableSalad.Models
{
    public class Plant: IVegetable
    {
        public string PlantType { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Taste { get; set; }
        public ushort CaloriesPerGram { get; set; }
    }
}
