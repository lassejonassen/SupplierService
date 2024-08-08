namespace SupplierService.Application.Products.Commands.UpdateProductProductType;

public sealed record UpdateProductProductTypeCommand(Guid ProductId, Guid ProductTypeId) : ICommand;
