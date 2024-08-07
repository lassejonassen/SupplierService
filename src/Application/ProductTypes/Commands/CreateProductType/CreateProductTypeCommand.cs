using SupplierService.Application.Abstractions.Messaging;

namespace SupplierService.Application.ProductTypes.Commands.CreateProductType;

public sealed record CreateProductTypeCommand(string Name, Guid SupplierId) : ICommand<Guid>;
