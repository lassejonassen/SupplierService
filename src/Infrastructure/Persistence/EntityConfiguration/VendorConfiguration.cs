using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VendorService.Infrastructure.Persistence.EntityConfiguration;

public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
	public void Configure(EntityTypeBuilder<Vendor> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder
			.HasMany(x => x.Products)
			.WithOne(x => x.Vendor!)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(x => x.Contacts)
			.WithOne(x => x.Vendor!)
			.HasForeignKey(x => x.VendorId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
