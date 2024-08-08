namespace VendorService.Application.Products.Commands.UpdateProductSKU;

public sealed record UpdateProductSKUCommand(Guid ProductId, string Sku) : ICommand;