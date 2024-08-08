namespace SupplierService.Application.ProductTypes.Commands.UpdateProductType;

public sealed record UpdateProductTypeCommand(ProductType ItemType) : ICommand;
