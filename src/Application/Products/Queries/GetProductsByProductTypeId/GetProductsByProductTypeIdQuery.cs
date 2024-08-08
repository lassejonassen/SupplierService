using VendorService.Domain.Entities;

namespace VendorService.Application.Products.Queries.GetProductsByProductTypeId;

public sealed record GetProductsByProductTypeIdQuery(Guid ProductTypeId) : IQuery<IEnumerable<Product>>;
