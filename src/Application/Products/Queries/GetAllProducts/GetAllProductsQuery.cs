using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;

namespace VendorService.Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery : IQuery<IEnumerable<Product>>;