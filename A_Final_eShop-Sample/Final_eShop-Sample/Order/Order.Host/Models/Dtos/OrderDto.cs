﻿using System.ComponentModel.DataAnnotations;

namespace Order.Host.Models.Dtos
{
	public class OrderDto
	{
		[Range(1, int.MaxValue, ErrorMessage = "Value must be non-negative > 0.")]
		[Required]
		public int Id { get; set; }

		[StringLength(100, MinimumLength = 0, ErrorMessage = "Unique number of an order is limited to 100 characters.")]
		[Required]
		public string SomeNumberOfOrder { get; set; } = null!;

		[Range(0, double.MaxValue, ErrorMessage = "Total price value of an order must be non-negative.")]
		[Required]
		public double TotalPrice { get; set; }

		public List<OrderItemsDto> OrderItems { get; set; } = null!;
	}
}