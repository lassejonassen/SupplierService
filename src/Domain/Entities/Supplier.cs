using SupplierService.Domain.Enums;
using SupplierService.Domain.Primitives;

namespace SupplierService.Domain.Entities;

public sealed record Supplier : Entity
{
	// Base Information
	public required string Name { get; set; }
	public required SupplierStatus Status { get; set; } = SupplierStatus.PendingApproval;
	
	public required string Street { get; set; }
	public required string City { get; set; }
	public required string PostalCode { get; set; }
	public required string Country { get; set; }
	public string? State { get; set; }

	public required string Email { get; set; }
	public required string Phone { get; set; }

	public string? Notes { get; set; }

	public ICollection<Contact>? Contacts { get; set; }
	public ICollection<Product>? Products { get; set; }


	public static Supplier Create(
		string name, 
		string street,
		string city, string postalCode,
		string country, string? state,
		string email, string phone,
		string? notes)
	{
		var supplier = new Supplier() {
			Id = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			CorrelationId = Guid.NewGuid(),
			Status = SupplierStatus.PendingApproval,
			Name = name,
			Street = street,
			City = city,
			PostalCode = postalCode,
			Country = country,
			State = state,
			Email = email,
			Phone = phone,
			Notes = notes
		};

		//supplier.Raise(new SupplierCreatedEvent {
		//	SupplierId = supplier.Id,
		//});

		return supplier;
	}
}
