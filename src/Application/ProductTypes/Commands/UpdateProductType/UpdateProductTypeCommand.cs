using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;

namespace SupplierService.Application.ProductTypes.Commands.UpdateProductType;

public sealed record UpdateProductTypeCommand(ProductType ItemType) : ICommand;
