using SupplierService.Domain.Primitives;

namespace SupplierService.Domain.Entities;

public sealed record ProductType : Entity
{
	public required string Name { get; set; }

	public required Guid SupplierId { get; set; }
	public required Supplier Supplier { get; set; }

	public ICollection<Product>? Products { get; set; }
}
