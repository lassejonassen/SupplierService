using VendorService.Domain.Entities;

namespace VendorService.Application.ProductTypes.Queries.GetAllProductTypes;

public sealed record GetAllProductTypesQuery : IQuery<IEnumerable<ProductType>>;
