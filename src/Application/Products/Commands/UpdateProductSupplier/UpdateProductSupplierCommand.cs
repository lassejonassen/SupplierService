namespace VendorService.Application.Products.Commands.UpdateProductSupplier;

public sealed record UpdateProductSupplierCommand(Guid ProductId, Guid SupplierId) : ICommand;