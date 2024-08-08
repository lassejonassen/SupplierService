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


	public static Product Create(
		string name,
		string? description,
		string sku,
		ProductType productType,
		Supplier supplier)
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
			SupplierId = supplier.Id,
			Supplier = supplier};

		//product.Raise(new ProductCreatedEvent {
		//	ProductId = product.Id,
		//});

		return product;
	}
}
