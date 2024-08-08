using VendorService.Domain.Entities;
using VendorService.Domain.Shared;

namespace VendorService.Domain.Repositories;

public interface IProductRepository
{
	Task<Result> AddAsync(Product product, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Product>>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<Product>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Product>>> GetByProductTypeIdAsync(Guid productTypeId, CancellationToken cancellationToken);
	Task<Result<IEnumerable<Product>>> GetBySupplierIdAsync(Guid supplierId, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(Product product, CancellationToken cancellationToken);
	Task<Result> UpdateSKUAsync(Guid id, string sku, CancellationToken cancellationToken);
	Task<Result> UpdateProductTypeAsync(Guid id, Guid productTypeId, CancellationToken cancellationToken);
	Task<Result> UpdateSupplierAsync(Guid id, Guid supplierId, CancellationToken cancellationToken);
	Task<Result> RemoveAsync(Guid id, CancellationToken cancellationToken);
	Task<bool> IsSKUUnique(string sku, CancellationToken cancellationToken);
}
