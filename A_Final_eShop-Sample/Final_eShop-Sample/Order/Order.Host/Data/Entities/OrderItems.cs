namespace Order.Host.Data.Entities
{
	public class OrderItems
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public int Amount { get; set; }

		public double Price { get; set; }
		public int OrderId { get; set; }
		public Order Order { get; set; } = null!;
	}
}
