﻿namespace MVC.Models.Requests
{
	public class AddProductRequest
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public decimal Price { get; set; }

		public string PictureFileName { get; set; } = null!;
	}
}