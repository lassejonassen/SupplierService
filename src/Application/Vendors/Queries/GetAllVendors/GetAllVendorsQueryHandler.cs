using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.VendorService.Application.Vendors.Queries.GetAllVendors;

internal sealed class GetAllVendorsQueryHandler : IQueryHandler<GetAllVendorsQuery, IEnumerable<Vendor>>
{
	private readonly IVendorRepository _repository;

	public GetAllVendorsQueryHandler(IVendorRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<IEnumerable<Vendor>>> Handle(GetAllVendorsQuery query, CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(cancellationToken);
	}
}
