using VendorService.Domain.Entities;

namespace VendorService.Application.Products.Queries.GetProductsBySupplierId;

public sealed record GetProductsBySupplierIdQuery(Guid SupplierId) : IQuery<IEnumerable<Product>>;