namespace VendorService.Infrastructure.Persistence.Repositories;

public class VendorRepository : IVendorRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger<VendorRepository> _logger;

	public VendorRepository(ApplicationDbContext dbContext, ILogger<VendorRepository> logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<Result> AddAsync(Vendor supplier, CancellationToken cancellationToken)
	{
		var result = await _dbContext.Vendors.AddAsync(supplier, cancellationToken);

		if (result is null)
		{
			_logger.LogError("Failed to add supplier to database.");
			return Result.Failure(DomainErrors.Vendor.FailedToAdd);
		}

		return Result.Success();
	}

	public async Task<Result<IEnumerable<Vendor>>> GetAllAsync(CancellationToken cancellationToken)
		=> await _dbContext.Vendors.ToListAsync(cancellationToken);

	public async Task<Result<Vendor>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Vendors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get supplier from database.");
			return Result.Failure<Vendor>(DomainErrors.Vendor.NotFound);
		}

		return entity;
	}

	public async Task<Result> UpdateAsync(Vendor vendor, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Vendors.FirstOrDefaultAsync(x => x.Id == vendor.Id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get Vendor from database.");
			return Result.Failure<ProductType>(DomainErrors.Vendor.NotFound);
		}
		entity.Name = vendor.Name;
		entity.Street = vendor.Street;
		entity.City = vendor.City;
		entity.PostalCode = vendor.PostalCode;
		entity.Country = vendor.Country;
		entity.State = vendor.State;
		entity.Email = vendor.Email;
		entity.Phone = vendor.Phone;
		entity.Notes = vendor.Notes;

		entity.UpdatedAt = DateTimeOffset.Now;
		entity.CorrelationId = Guid.NewGuid();

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
	}

	public async Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Vendors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get supplier from database.");
			return Result.Failure<Vendor>(DomainErrors.Vendor.NotFound);
		}

		var result = _dbContext.Vendors.Remove(entity);

		if (result.State != EntityState.Deleted)
		{
			_logger.LogError("Failed to remove supplier from database");
			return Result.Failure(DomainErrors.Vendor.FailedToRemove);
		}

		return Result.Success();
	}

	public async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
	{
		var exists = await _dbContext.Vendors.AnyAsync(x => x.Email == email, cancellationToken);
		return !exists;
	}

	public async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken)
	{
		var exists = await _dbContext.Vendors
			.AnyAsync(x => x.Name.Replace(" ", "").ToUpper() == name.Replace(" ", "").ToUpper(), cancellationToken);

		return !exists;
	}

	
}
