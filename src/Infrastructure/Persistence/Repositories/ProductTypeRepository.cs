using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VendorService.Domain.Errors;
using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Infrastructure.Persistence.Repositories;

public sealed class ProductTypeRepository : IProductTypeRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger<ProductTypeRepository> _logger;

	public ProductTypeRepository(ApplicationDbContext dbContext, ILogger<ProductTypeRepository> logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	private IQueryable Entities => _dbContext.ProductTypes;

	public async Task<Result> AddAsync(ProductType productType, CancellationToken cancellationToken)
	{
		var result = await _dbContext.ProductTypes.AddAsync(productType, cancellationToken);

		if (result is null)
		{
			return Result.Failure(DomainErrors.ProductType.FailedToAdd);
		}

		return Result.Success();
	}

	public async Task<Result<IEnumerable<ProductType>>> GetAllAsync(CancellationToken cancellationToken)
		=> await _dbContext.ProductTypes.ToListAsync(cancellationToken);

	public async Task<Result<ProductType>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.ProductTypes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get PRODUCT TYPE from database.");
			return Result.Failure<ProductType>(DomainErrors.ProductType.NotFound);
		}

		return entity;
	}

	public async Task<Result> UpdateAsync(ProductType productType, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.ProductTypes.FirstOrDefaultAsync(x => x.Id == productType.Id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get PRODUCT TYPE from database.");
			return Result.Failure<ProductType>(DomainErrors.ProductType.NotFound);
		}

		entity.Name = productType.Name;
		entity.UpdatedAt = DateTimeOffset.Now;
		entity.CorrelationId = Guid.NewGuid();

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
	}

	public  async Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.ProductTypes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get PRODUCT TYPE from database.");
			return Result.Failure(DomainErrors.ProductType.NotFound);
		}

		var result = _dbContext.ProductTypes.Remove(entity);

		if (result.State != EntityState.Deleted)
		{
			_logger.LogError("Failed to remove PRODUCT TYPE from database");
			return Result.Failure(DomainErrors.ProductType.FailedToRemove);
		}

		return Result.Success();
	}
}
