using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;

namespace SupplierService.Application.ProductTypes.Queries.GetAllProductTypes;

public sealed record GetAllProductTypesQuery : IQuery<IEnumerable<ProductType>>;
