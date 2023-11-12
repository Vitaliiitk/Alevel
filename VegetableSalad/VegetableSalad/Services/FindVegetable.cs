namespace VegetableSalad.Services
{
    internal class FindVegetable
    {
        public void FindTheMostCaloricVegetable(MakeSalad saladDish)
        {
            var mySalad = saladDish.MySalad();
            double caloriesOfVegetable = (double)(mySalad[0].CaloriesPerGram) / (double)(100) * mySalad[0].Weight;
            int index = 0;

            foreach (var item in mySalad)
            {
                double calories = (double)(item.CaloriesPerGram) / (double)(100) * item.Weight;

                if (calories > caloriesOfVegetable)
                {
                    caloriesOfVegetable = calories;
                    index = mySalad.IndexOf(item);
                }
            }

            Console.WriteLine($"The most caloric vegetable has {caloriesOfVegetable} calories, this is a {mySalad[index].Name} " +
                $"and we added it to our salad on {index + 1} step.");
        }
    }
}
