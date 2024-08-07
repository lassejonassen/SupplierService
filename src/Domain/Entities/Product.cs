using SupplierService.Domain.Primitives;

namespace SupplierService.Domain.Entities;

public sealed record Product : Entity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required string SKU { get; set; }
	public required Guid ProductTypeId { get; set; }
	public required ProductType ProductType { get; set; }
	public required Guid SupplierId { get; set; }
	public required Supplier Supplier { get; set; }
}
