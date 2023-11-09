using VegetableSalad.Services;

namespace VegetableSalad
{
    internal class App
    {
        public void Start()
        {
            Console.WriteLine("You can add to your salad plate \"paprika\", \"tomato\", \"green salad\", \"cucumber\". When you finish with adding, write \"stop\" \n");
            MakeSalad makeSalad = new MakeSalad();
            makeSalad.Salad();
            Console.WriteLine();
            foreach (var item in makeSalad.saladDish)
            {
                Console.Write(item.Name + " " + "and it's weight ->" + item.Weight + " ");
            }

            if (makeSalad.saladDish.Count() != 0)
            {
                CalcCalories calcCalories = new CalcCalories();
                calcCalories.Calculate(makeSalad);
                FindVegetable findVegetable = new FindVegetable();
                
                findVegetable.FindTheMostCaloricVegetable(makeSalad);
                
                SortVegetables sort = new SortVegetables();
                sort.SortVegetablesInSaladByWeight(makeSalad);
            }
            else
            {
                Console.WriteLine("Your salad plate is empty");
            }
        }
    }
}
