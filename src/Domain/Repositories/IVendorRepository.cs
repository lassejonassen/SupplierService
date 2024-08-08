using VendorService.Domain.Entities;
using VendorService.Domain.Shared;

namespace VendorService.Domain.Repositories;

public interface IVendorRepository
{
	Task<Result> AddAsync(Vendor vendor, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Vendor>>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<Vendor>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(Vendor vendor, CancellationToken cancellationToken);
	Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken);

	Task<bool> IsNameUnique(string name, CancellationToken cancellationToken);
	Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken);

}
