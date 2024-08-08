namespace SupplierService.Application.Products.Queries.GetProductById;

internal sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Product>
{
	private readonly IProductRepository _productRepository;

	public GetProductByIdQueryHandler(IProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	public async Task<Result<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
	{
		var result = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure<Product>(result.Error);
		}

		return result.Value;
	}
}