using SupplierService.Application.Abstractions.Messaging;

namespace SupplierService.Application.ProductTypes.Commands.DeleteProductType;

public sealed record DeleteProductTypeCommand(Guid Id) : ICommand;
