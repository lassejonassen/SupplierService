using VendorService.Domain.Entities;

namespace VendorService.Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IQuery<Product>;