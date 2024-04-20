using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Host.Data.Entities;

namespace Order.Host.Data.EntityConfigurations
{
	public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Entities.Order>
	{
		public void Configure(EntityTypeBuilder<Entities.Order> builder)
		{
			builder.ToTable("Orders");

			builder.Property(ci => ci.Id)
				.UseHiLo("order_hilo")
				.IsRequired();

			builder.Property(ci => ci.SomeNumberOfOrder)
				.IsRequired(true)
				.HasMaxLength(50);

			builder.Property(ci => ci.TotalPrice)
				.IsRequired(true);

			builder.HasMany(o => o.OrderItems)
				   .WithOne(oi => oi.Order)
				   .HasForeignKey(oi => oi.OrderId);
		}
	}
}
