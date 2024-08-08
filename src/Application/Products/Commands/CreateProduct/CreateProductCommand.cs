using VendorService.Application.Abstractions.Messaging;

namespace VendorService.Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
	string Name,
	string? Description,
	string SKU,
	Guid ProductTypeId,
	Guid SupplierId) : ICommand<Guid>;