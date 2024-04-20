using Microsoft.EntityFrameworkCore;
using Order.Host.Data.Entities;
using Order.Host.Data.EntityConfigurations;

namespace Order.Host.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
	   : base(options)
		{
		}

		public DbSet<Entities.Order> Orders { get; set; } = null!;
		public DbSet<OrderItems> OrderItems { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new OrderEntityTypeConfiguration());
			builder.ApplyConfiguration(new OrderItemsEntityTypeConfiguration());
		}
	}
}
