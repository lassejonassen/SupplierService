using VendorService.Domain.Entities;

namespace VendorService.Application.ProductTypes.Commands.UpdateProductType;

public sealed record UpdateProductTypeCommand(ProductType ItemType) : ICommand;
