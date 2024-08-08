using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.ProductTypes.Queries.GetAllProductTypes;

internal sealed class GetAllProductTypesQueryHandler : IQueryHandler<GetAllProductTypesQuery, IEnumerable<ProductType>>
{
	private readonly IProductTypeRepository _repository;

	public GetAllProductTypesQueryHandler(IProductTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<IEnumerable<ProductType>>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetAllAsync(cancellationToken);
	}
}
