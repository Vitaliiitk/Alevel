using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Host.Data.Entities;

namespace Order.Host.Data.EntityConfigurations
{
	public class OrderItemsEntityTypeConfiguration : IEntityTypeConfiguration<OrderItems>
	{
		public void Configure(EntityTypeBuilder<OrderItems> builder)
		{
			builder.ToTable("OrderItems");

			builder.HasKey(ci => ci.Id);

			builder.Property(ci => ci.Id)
				.UseHiLo("orderItems_hilo")
				.IsRequired();

			builder.Property(cb => cb.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(ci => ci.Amount)
				.IsRequired(true);

			builder.Property(ci => ci.Price)
				.IsRequired(true);
		}
	}
}
