using SupplierService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryService.Infrastructure.Persistence.EntityConfigurations;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
	public void Configure(EntityTypeBuilder<ProductType> builder)
	{
		builder.HasKey(x => x.Id);
		
		builder.Property(x => x.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder.HasMany(x => x.Products)
			.WithOne(x => x.ProductType)
			.HasForeignKey(x => x.ProductTypeId)
			.IsRequired()
			.OnDelete(DeleteBehavior.Restrict);
	}
}
