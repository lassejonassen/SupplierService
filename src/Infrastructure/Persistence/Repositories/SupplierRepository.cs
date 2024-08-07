﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SupplierService.Domain.Entities;
using SupplierService.Domain.Errors;
using SupplierService.Domain.Repositories;
using SupplierService.Domain.Shared;

namespace SupplierService.Infrastructure.Persistence.Repositories;

public class SupplierRepository : ISupplierRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger<SupplierRepository> _logger;

	public SupplierRepository(ApplicationDbContext dbContext, ILogger<SupplierRepository> logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<Result> AddAsync(Supplier supplier, CancellationToken cancellationToken)
	{
		var result = await _dbContext.Suppliers.AddAsync(supplier, cancellationToken);

		if (result is null)
		{
			_logger.LogError("Failed to add supplier to database.");
			return Result.Failure(DomainErrors.Supplier.FailedToAdd);
		}

		return Result.Success();
	}

	public async Task<Result<IEnumerable<Supplier>>> GetAllAsync(CancellationToken cancellationToken)
		=> await _dbContext.Suppliers.ToListAsync(cancellationToken);

	public async Task<Result<Supplier>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get supplier from database.");
			return Result.Failure<Supplier>(DomainErrors.Supplier.NotFound);
		}

		return entity;
	}

	public async Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get supplier from database.");
			return Result.Failure<Supplier>(DomainErrors.Supplier.NotFound);
		}

		var result = _dbContext.Suppliers.Remove(entity);

		if (result.State != EntityState.Deleted)
		{
			_logger.LogError("Failed to remove supplier from database");
			return Result.Failure(DomainErrors.Supplier.FailedToRemove);
		}

		return Result.Success();
	}

	public async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
	{
		var exists = await _dbContext.Suppliers.AnyAsync(x => x.Email == email, cancellationToken);
		return !exists;
	}

	public async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken)
	{
		var exists = await _dbContext.Suppliers
			.AnyAsync(x => x.Name.Replace(" ", "").ToUpper() == name.Replace(" ", "").ToUpper(), cancellationToken);

		return !exists;
	}
}
