namespace MVC.ViewModels.OrderViewModels
{
	public class IndexViewModel
	{
		public string SomeNumberOfOrder { get; set; } = null!;
		public double TotalPrice { get; set; }

		public List<OrderProducts> OrderProducts { get; set; } = null!;
	}
}
