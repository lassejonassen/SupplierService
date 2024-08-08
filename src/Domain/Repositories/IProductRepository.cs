using SupplierService.Domain.Entities;
using SupplierService.Domain.Shared;

namespace SupplierService.Domain.Repositories;

public interface IProductRepository
{
	Task<Result> AddAsync(Product product, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Product>>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<Product>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(Product product, CancellationToken cancellationToken);
	Task<Result> UpdateSKUAsync(Guid id, string sku, CancellationToken cancellationToken);
	Task<Result> UpdateProductType(Guid id, Guid productTypeId, CancellationToken cancellationToken);
	Task<Result> UpdateSupplier(Guid id, Guid supplierId, CancellationToken cancellationToken);
	Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken);
	Task<bool> IsSKUUnique(string sku, CancellationToken cancellationToken);
}
