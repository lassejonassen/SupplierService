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

	public async Task<Result<IEnumerable<Product>>> GetBySupplierIdAsync(Guid supplierId, CancellationToken cancellationToken)
		=> await _dbContext.Products.Where(x => x.SupplierId == supplierId).ToListAsync(cancellationToken);


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

	public async Task<Result<IEnumerable<Product>>> GetByProductTypeIdAsync(Guid productTypeId, CancellationToken cancellationToken)
		=> await _dbContext.Products.Where(x => x.ProductTypeId == productTypeId).ToListAsync(cancellationToken);

	public async Task<Result> UpdateAsync(Product product, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == product.Id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get product from database.");
			return Result.Failure<Product>(DomainErrors.Product.NotFound);
		}

		entity.CorrelationId = Guid.NewGuid();
		entity.UpdatedAt = DateTimeOffset.Now;

		entity.Name = product.Name;

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
	}

	public async Task<Result> UpdateSKUAsync(Guid id, string sku, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get product from database.");
			return Result.Failure<Product>(DomainErrors.Product.NotFound);
		}

		entity.CorrelationId = Guid.NewGuid();
		entity.UpdatedAt = DateTimeOffset.Now;

		entity.SKU = sku;

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
	}

	public async Task<Result> UpdateProductTypeAsync(Guid id, Guid productTypeId , CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get product from database.");
			return Result.Failure(DomainErrors.Product.NotFound);
		}

		var productType = await _dbContext.ProductTypes.FirstOrDefaultAsync(x => x.Id == productTypeId, cancellationToken);

		if (productType is null)
		{
			_logger.LogError("Failed to get product type from database");
			return Result.Failure(DomainErrors.ProductType.NotFound);
		}

		entity.CorrelationId = Guid.NewGuid();
		entity.UpdatedAt = DateTimeOffset.Now;

		entity.ProductTypeId = productTypeId;
		entity.ProductType = productType;

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
	}

	public async Task<Result> UpdateSupplierAsync(Guid id, Guid supplierId, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get product from database.");
			return Result.Failure(DomainErrors.Product.NotFound);
		}

		var supplier = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == supplierId, cancellationToken);

		if (supplier is null)
		{
			_logger.LogError("Failed to get supplier from database");
			return Result.Failure(DomainErrors.Supplier.NotFound);
		}

		entity.CorrelationId = Guid.NewGuid();
		entity.UpdatedAt = DateTimeOffset.Now;

		entity.SupplierId= supplierId;
		entity.Supplier = supplier;

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
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

	public async Task<bool> IsSKUUnique(string sku, CancellationToken cancellationToken)
	{
		var exists = await _dbContext.Products.AnyAsync(x => x.SKU == sku, cancellationToken);
		return !exists;
	}

	
}
