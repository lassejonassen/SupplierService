namespace SupplierService.Application.Products.Queries.GetProductsByProductTypeId;

public sealed record GetProductsByProductTypeIdQuery(Guid ProductTypeId) : IQuery<IEnumerable<Product>>;
