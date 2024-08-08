using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendorService.Domain.Entities;

namespace VendorService.Infrastructure.SupplierService.Infrastructure.Persistence.EntityConfiguration;
public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
	public void Configure(EntityTypeBuilder<Contact> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.Vendor)
			.WithMany(x => x.Contacts)
			.HasForeignKey(x => x.VendorId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
