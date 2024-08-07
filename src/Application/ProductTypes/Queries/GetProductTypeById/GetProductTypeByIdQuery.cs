using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;

namespace SupplierService.Application.ProductTypes.Queries.GetProductTypeById;

public sealed record GetProductTypeByIdQuery(Guid Id) : IQuery<ProductType>;
