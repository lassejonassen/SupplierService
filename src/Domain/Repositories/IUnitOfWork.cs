namespace VendorService.Domain.Repositories;

public interface IUnitOfWork
{
	Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
