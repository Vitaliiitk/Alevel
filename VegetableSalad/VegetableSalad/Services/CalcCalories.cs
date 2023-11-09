namespace VegetableSalad.Services
{
    internal class CalcCalories
    {

        public double calories = 0;

        public void Calculate(MakeSalad saladDish)
        {
            var mySalad = saladDish.MySalad();

            foreach (var item in mySalad)
            {
                calories = (calories + item.CaloriesPerGram * item.Weight / 100);
            }

            Console.WriteLine($"\n\nTotal kilocalories in salad = {calories} kilocalories");
        }
    }
}
