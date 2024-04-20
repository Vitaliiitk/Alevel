﻿namespace Order.Host.Data
{
	public class DbInitializer
	{
		public static async Task Initialize(ApplicationDbContext context)
		{
			await context.Database.EnsureCreatedAsync();
		}
	}
}
