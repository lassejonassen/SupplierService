using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;

namespace SupplierService.Application.Suppliers.Queries.GetAllSuppliers;

public sealed record GetAllSuppliersQuery : IQuery<IEnumerable<Supplier>>;