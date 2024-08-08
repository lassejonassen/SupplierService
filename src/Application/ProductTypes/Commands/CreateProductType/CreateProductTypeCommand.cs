namespace VendorService.Application.ProductTypes.Commands.CreateProductType;

public sealed record CreateProductTypeCommand(string Name, Guid SupplierId) : ICommand<Guid>;
