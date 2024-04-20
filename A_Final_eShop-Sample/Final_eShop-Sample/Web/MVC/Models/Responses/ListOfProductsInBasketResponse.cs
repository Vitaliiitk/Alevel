namespace MVC.Models.Responses
{
    public class ListOfProductsInBasketResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Amount { get; set; }

        public string PictureFileName { get; set; } = null!;
    }
}
