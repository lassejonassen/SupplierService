using VendorService.Domain.Primitives;

namespace VendorService.Domain.Entities;

public sealed record ProductType : Entity
{
	public required string Name { get; set; }

	public required Guid VendorId { get; set; }
	public required Vendor Vendor { get; set; }

	public ICollection<Product>? Products { get; set; }
}
