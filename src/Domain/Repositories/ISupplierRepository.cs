using SupplierService.Domain.Entities;
using SupplierService.Domain.Shared;

namespace SupplierService.Domain.Repositories;

public interface ISupplierRepository
{
	Task<Result> AddAsync(Supplier supplier, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Supplier>>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<Supplier>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken);

	Task<bool> IsNameUnique(string name, CancellationToken cancellationToken);
	Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken);

}
