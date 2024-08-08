using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendorService.Domain.Entities;

namespace VendorService.Infrastructure.Persistence.EntityConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(x => x.Description)
			.HasMaxLength(255);

		builder.Property(x => x.SKU)
			.IsRequired();

		builder.HasOne(x => x.ProductType)
			.WithMany(x => x.Products)
			.HasForeignKey(x => x.ProductTypeId)
			.IsRequired();

		builder.HasOne(x => x.Vendor)
			.WithMany(x => x.Products)
			.HasForeignKey(x => x.VendorId);
	}
}
