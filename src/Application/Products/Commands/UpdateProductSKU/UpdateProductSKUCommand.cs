using VendorService.Application.Abstractions.Messaging;

namespace VendorService.Application.Products.Commands.UpdateProductSKU;

public sealed record UpdateProductSKUCommand(Guid ProductId, string Sku) : ICommand;