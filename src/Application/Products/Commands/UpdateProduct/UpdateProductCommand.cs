using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;

namespace VendorService.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(Product Product) : ICommand;
