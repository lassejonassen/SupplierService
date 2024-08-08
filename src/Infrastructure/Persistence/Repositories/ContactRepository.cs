using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VendorService.Domain.Errors;
using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;
using VendorService.Infrastructure.SupplierService.Infrastructure.Persistence;

namespace VendorService.Infrastructure.SupplierService.Infrastructure.Persistence.Repositories;

public sealed class ContactRepository : IContactRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger<ContactRepository> _logger;

	public ContactRepository(ApplicationDbContext dbContext, ILogger<ContactRepository> logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<Result> AddAsync(Contact contact, CancellationToken cancellationToken)
	{
		var result = await _dbContext.Contacts.AddAsync(contact, cancellationToken);

		if (result is null)
		{
			_logger.LogError("Failed to add contact to database.");
			return Result.Failure(DomainErrors.Contact.FailedToAdd);
		}

		return Result.Success();
	}

	public async Task<Result<IEnumerable<Contact>>> GetAllAsync(CancellationToken cancellationToken)
		=> await _dbContext.Contacts.ToListAsync(cancellationToken);

	public async Task<Result<Contact>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get contact from database.");
			return Result.Failure<Contact>(DomainErrors.Contact.NotFound);
		}

		return entity;
	}

	public async Task<Result<IEnumerable<Contact>>> GetBySupplierIdAsync(Guid supplierId, CancellationToken cancellationToken)
	{
		return await _dbContext.Contacts
			.Where(x => x.VendorId == supplierId)
			.ToListAsync(cancellationToken);
	}

	public async Task<Result> UpdateAsync(Contact contact, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == contact.Id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get contact from database.");
			return Result.Failure(DomainErrors.Contact.NotFound);
		}

		entity.CorrelationId = Guid.NewGuid();
		entity.UpdatedAt = DateTimeOffset.Now;

		entity.FirstName = contact.FirstName;
		entity.LastName = contact.LastName;
		entity.Email = contact.Email;
		entity.Phone = contact.Phone;
		entity.Notes = contact.Notes;

		_dbContext.Entry(entity).State = EntityState.Modified;

		return Result.Success();
	}

	public async Task<Result> UpdateSupplierReferenceAsync(Guid contactId, Guid supplierId, CancellationToken cancellationToken)
	{
		var contactEntity = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == contactId, cancellationToken);

		if (contactEntity is null)
		{
			_logger.LogError("Failed to get contact from database.");
			return Result.Failure(DomainErrors.Contact.NotFound);
		}

		var supplierEntity = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == supplierId, cancellationToken);

		if (supplierEntity is null)
		{
			_logger.LogError("Failed to get supplier from database.");
			return Result.Failure(DomainErrors.Vendor.NotFound);
		}

		contactEntity.CorrelationId = Guid.NewGuid();
		contactEntity.UpdatedAt = DateTimeOffset.Now;
		contactEntity.VendorId = supplierId;

		_dbContext.Entry(contactEntity).State = EntityState.Modified;

		return Result.Success();
	}

	public async Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

		if (entity is null)
		{
			_logger.LogError("Failed to get contact from database.");
			return Result.Failure(DomainErrors.Contact.NotFound);
		}

		var result = _dbContext.Contacts.Remove(entity);

		if (result.State != EntityState.Deleted)
		{
			_logger.LogError("Failed to remove contact from database");
			return Result.Failure(DomainErrors.Contact.FailedToRemove);
		}

		return Result.Success();
	}

	public async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken)
	{
		var exists = await _dbContext.Contacts.AnyAsync(x => x.Email == email, cancellationToken);
		return !exists;
	}


}
