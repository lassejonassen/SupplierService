using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.VendorService.Application.Vendors.Queries.GetVendorById;

internal sealed class GetVendorByIdQueryHandler : IQueryHandler<GetVendorByIdQuery, Vendor>
{
	private readonly IVendorRepository _repository;

	public GetVendorByIdQueryHandler(IVendorRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<Vendor>> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
	{
		var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure<Vendor>(result.Error);
		}

		return result.Value;
	}
}
