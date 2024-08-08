namespace SupplierService.Application.ProductTypes.Queries.GetProductTypeById;

internal sealed class GetProductTypeByIdQueryHandler : IQueryHandler<GetProductTypeByIdQuery, ProductType>
{
	private readonly IProductTypeRepository _repository;

	public GetProductTypeByIdQueryHandler(IProductTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<ProductType>> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
	{
		var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure<ProductType>(result.Error);
		}

		return result.Value;
	}
}
