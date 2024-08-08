namespace SupplierService.Application.Suppliers.Queries.GetAllSuppliers;

public sealed record GetAllSuppliersQuery : IQuery<IEnumerable<Supplier>>;