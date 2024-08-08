using VendorService.Application.Abstractions.Messaging;

namespace VendorService.Application.Products.Commands.UpdateProductSupplier;

public sealed record UpdateProductSupplierCommand(Guid ProductId, Guid SupplierId) : ICommand;