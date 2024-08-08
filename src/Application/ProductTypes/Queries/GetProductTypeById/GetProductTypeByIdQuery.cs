namespace SupplierService.Application.ProductTypes.Queries.GetProductTypeById;

public sealed record GetProductTypeByIdQuery(Guid Id) : IQuery<ProductType>;
