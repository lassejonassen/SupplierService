namespace SupplierService.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(Product Product) : ICommand;
