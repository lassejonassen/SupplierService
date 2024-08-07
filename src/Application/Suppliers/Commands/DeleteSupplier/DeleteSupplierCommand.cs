using SupplierService.Application.Abstractions.Messaging;

namespace SupplierService.Application.Suppliers.Commands.DeleteSupplier;

public sealed record DeleteSupplierCommand(Guid Id) : ICommand;