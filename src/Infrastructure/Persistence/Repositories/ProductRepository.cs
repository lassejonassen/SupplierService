using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SupplierService.Domain.Entities;
using SupplierService.Domain.Errors;
using SupplierService.Domain.Repositories;
using SupplierService.Domain.Shared;

namespace SupplierService.Infrastructure.Persistence.Repositories;

public sealed class ProductRepository : IProductRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger<ProductRepository> _logger;

	public ProductRepository(ApplicationDbContext dbContext, ILogger<ProductRepository> logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<Result> AddAsync(Product product, CancellationToken cancellationToken)
	{
		var result = await _dbContext.Products.AddAsync(product, cancellationToken);

		if (result is null)
		{
			_logger.LogError("Failed to add product to database.");
			return Result.Failure(DomainErrors.Product.FailedToAdd);
		}

		return Result.Success();
	}

	public async Task<Result<IEnumerable<Product>>> GetAllAsync(CancellationToken cancellationToken)
		=> await _dbContext.Products.ToListAsync(cancellationToken);


	public async Task<Result<Product>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get product from database.");
			return Result.Failure<Product>(DomainErrors.Product.NotFound);
		}

		return entity;
	}
	

	public Task<Result> UpdateAsync(Product product, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public async Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get product from database.");
			return Result.Failure(DomainErrors.Product.NotFound);
		}

		var result = _dbContext.Products.Remove(entity);

		if (result.State != EntityState.Deleted)
		{
			_logger.LogError("Failed to remove product from database");
			return Result.Failure(DomainErrors.Product.FailedToRemove);
		}

		return Result.Success();
	}
}
