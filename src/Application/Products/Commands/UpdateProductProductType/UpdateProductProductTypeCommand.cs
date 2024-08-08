using VendorService.Application.Abstractions.Messaging;

namespace VendorService.Application.Products.Commands.UpdateProductProductType;

public sealed record UpdateProductProductTypeCommand(Guid ProductId, Guid ProductTypeId) : ICommand;
