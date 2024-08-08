namespace SupplierService.Application.Products.Commands.DeleteProduct;

internal sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
{
	private readonly IProductRepository _productRepository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
	{
		_productRepository = productRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
	{
		var result = await _productRepository.RemoveAsync(request.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		return Result.Success();
	}
}
