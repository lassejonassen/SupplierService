﻿using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;
using SupplierService.Domain.Repositories;
using SupplierService.Domain.Shared;

namespace SupplierService.Application.Suppliers.Queries.GetAllSuppliers;

internal sealed class GetAllSuppliersQueryHandler : IQueryHandler<GetAllSuppliersQuery, IEnumerable<Supplier>>
{
	private readonly ISupplierRepository _repository;

	public GetAllSuppliersQueryHandler(ISupplierRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<IEnumerable<Supplier>>> Handle(GetAllSuppliersQuery query, CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(cancellationToken);
	}
}
