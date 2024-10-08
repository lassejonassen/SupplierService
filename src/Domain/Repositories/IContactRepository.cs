﻿using VendorService.Domain.Entities;
using VendorService.Domain.Shared;

namespace VendorService.Domain.Repositories;

public interface IContactRepository
{
	Task<Result> AddAsync(Contact contact, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Contact>>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<Contact>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Contact>>> GetBySupplierIdAsync(Guid supplierId, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(Contact contact, CancellationToken cancellationToken);
	Task<Result> UpdateSupplierReferenceAsync(Guid contactId, Guid supplierId, CancellationToken cancellationToken);
	Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken);

	Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken);
}
