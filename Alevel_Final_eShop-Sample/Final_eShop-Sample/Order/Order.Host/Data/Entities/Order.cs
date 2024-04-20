namespace Order.Host.Data.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public string SomeNumberOfOrder { get; set; } = null!;
		public double TotalPrice { get; set; }

		public List<OrderItems> OrderItems { get; set; } = null!;
	}
}
