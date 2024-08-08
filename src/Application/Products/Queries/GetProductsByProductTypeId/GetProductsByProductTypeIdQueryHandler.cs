namespace SupplierService.Application.Products.Queries.GetProductsByProductTypeId;

internal sealed class GetProductsByProductTypeIdQueryHandler : IQueryHandler<GetProductsByProductTypeIdQuery, IEnumerable<Product>>
{
	private readonly IProductRepository _repository;

	public GetProductsByProductTypeIdQueryHandler(IProductRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<IEnumerable<Product>>> Handle(GetProductsByProductTypeIdQuery query, CancellationToken cancellationToken)
	{
		return await _repository.GetByProductTypeIdAsync(query.ProductTypeId, cancellationToken);
	}
}