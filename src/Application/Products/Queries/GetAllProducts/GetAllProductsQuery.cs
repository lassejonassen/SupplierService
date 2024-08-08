namespace SupplierService.Application.Products.Queries.GetAllProducts;

public sealed record GetAllProductsQuery : IQuery<IEnumerable<Product>>;