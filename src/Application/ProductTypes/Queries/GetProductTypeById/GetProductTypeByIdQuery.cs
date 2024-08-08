using VendorService.Domain.Entities;

namespace VendorService.Application.ProductTypes.Queries.GetProductTypeById;

public sealed record GetProductTypeByIdQuery(Guid Id) : IQuery<ProductType>;
