namespace SupplierService.Application.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id): ICommand;