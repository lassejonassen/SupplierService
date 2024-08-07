using SupplierService.Domain.Entities;
using SupplierService.Domain.Shared;

namespace SupplierService.Domain.Repositories;

public interface IProductTypeRepository
{
	Task<Result> AddAsync(ProductType productType, CancellationToken cancellationToken);
	Task<Result<IEnumerable<ProductType>>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<ProductType>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(ProductType productType, CancellationToken cancellationToken);
	Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken);
}
