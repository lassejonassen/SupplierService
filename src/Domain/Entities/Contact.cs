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

	public static Contact Create(
		string firstName, string lastName,
		string email, string phone,
		string? notes,
		Supplier supplier)
	{
		var contact = new Contact ()
		{
			Id = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			CorrelationId = Guid.NewGuid(),
			FirstName = firstName,
			LastName = lastName,
			Email = email,
			Phone = phone,
			Notes = notes,
			SupplierId = supplier.Id,
			Supplier = supplier
		};

		//contact.Raise(new ContactCreatedEvent {
		//	ContactId = contact.Id,
		//});

		return contact;
	}
}
