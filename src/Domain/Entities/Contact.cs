using SupplierService.Domain.Primitives;

namespace SupplierService.Domain.Entities;

public sealed record Contact : Entity
{
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public required string Email { get; set; }
	public required string Phone { get; set; }
	public string? Notes { get; set; }

	public required Guid SupplierId { get; set; }
	public required Supplier Supplier { get; set; }
}
