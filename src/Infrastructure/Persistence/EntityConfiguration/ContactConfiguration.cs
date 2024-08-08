using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplierService.Domain.Entities;

namespace SupplierService.Infrastructure.Persistence.EntityConfiguration;
public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
	public void Configure(EntityTypeBuilder<Contact> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.Supplier)
			.WithMany(x => x.Contacts)
			.HasForeignKey(x => x.SupplierId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
