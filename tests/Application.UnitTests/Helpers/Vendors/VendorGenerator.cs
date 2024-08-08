using VendorService.Domain.Entities;

namespace VendorService.Application.UnitTests.Helpers.Vendors;
public static class VendorGenerator
{
	public static Vendor Vendor()
	{
		return new Vendor() {
			Id = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			CorrelationId = Guid.NewGuid(),
			Name = "Vendor Name",
			Street = "Vendor Address",
			City = "Some city",
			PostalCode = "1234",
			Country = "Denmark",
			Phone = "12341234",
			Email = "vendor@mail.com",
			Notes = null,
			Status = Domain.Enums.VendorStatus.Active
		};
	}
}
