

namespace VegetableSalad.Services
{
    internal class SortVegetables
    {
        public void SortVegetablesInSaladByWeight(MakeSalad saladDish)
        {
            var mySalad = saladDish.MySalad();
            var enum1 = from vegetable in mySalad orderby vegetable.Weight select vegetable;
            Console.WriteLine("From lightest  to heviest vegetable weight:");
            foreach (var e in enum1)
            {
                Console.WriteLine(e.Name + " has weight " + e.Weight + " gram");
            }
            Console.WriteLine("From heviest to lightest vegetable wight:");
            var enum2 = from vegetable in mySalad orderby vegetable.Weight descending select vegetable;
            foreach (var e in enum2)
            {
                Console.WriteLine(e.Name + " has weight " + e.Weight + " gram");
            }
        }
    }
}
