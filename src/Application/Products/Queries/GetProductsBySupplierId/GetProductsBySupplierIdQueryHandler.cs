namespace SupplierService.Application.Products.Queries.GetProductsBySupplierId;

internal sealed class GetProductsBySupplierIdQueryHandler : IQueryHandler<GetProductsBySupplierIdQuery, IEnumerable<Product>>
{
	private readonly IProductRepository _repository;

	public GetProductsBySupplierIdQueryHandler(IProductRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<IEnumerable<Product>>> Handle(GetProductsBySupplierIdQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetBySupplierIdAsync(request.SupplierId, cancellationToken);
	}
}
