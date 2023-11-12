using NewYearsGift.Models;
using NewYearsGift.Services;

namespace NewYearsGift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gift gif = new Gift();
            gif.GiftBox();
            Console.WriteLine($"The weight of our box is {gif.boxWeight} gram: ");
            gif.GiftContains();
            Search src = new Search();
            src.SearchLightest();
            Sort srt = new Sort();
            srt.SortBox();

        }
    }
}