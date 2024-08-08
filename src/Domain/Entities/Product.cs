using VendorService.Domain.Primitives;

namespace VendorService.Domain.Entities;

public sealed record Product : Entity
{
	public required string Name { get; set; }
	public string? Description { get; set; }
	public required string SKU { get; set; }
	public required Guid ProductTypeId { get; set; }
	public required ProductType ProductType { get; set; }
	public required Guid VendorId { get; set; }
	public required Vendor Vendor { get; set; }


	public static Product Create(
		string name,
		string? description,
		string sku,
		ProductType productType,
		Vendor supplier)
	{
		var product = new Product() {
			Id = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			CorrelationId = Guid.NewGuid(),
			Name = name,
			Description = description,
			SKU = sku,
			ProductTypeId = productType.Id,
			ProductType = productType,
			VendorId = supplier.Id,
			Vendor = supplier
		};

		//product.Raise(new ProductCreatedEvent {
		//	ProductId = product.Id,
		//});

		return product;
	}
}
