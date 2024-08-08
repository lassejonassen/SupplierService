﻿namespace SupplierService.Application.Suppliers.Queries.GetSupplierById;

public sealed record GetSupplierByIdQuery(Guid Id) : IQuery<Supplier>;