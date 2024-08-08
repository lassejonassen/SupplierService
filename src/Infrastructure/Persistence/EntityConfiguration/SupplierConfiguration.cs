using SupplierService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SupplierService.Infrastructure.Persistence.EntityConfiguration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
	public void Configure(EntityTypeBuilder<Supplier> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder
			.HasMany(x => x.Products)
			.WithOne(x => x.Supplier!)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(x => x.Contacts)
			.WithOne(x => x.Supplier!)
			.HasForeignKey(x => x.SupplierId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
