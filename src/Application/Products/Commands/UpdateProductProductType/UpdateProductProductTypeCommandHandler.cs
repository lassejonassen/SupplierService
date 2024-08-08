namespace SupplierService.Application.Products.Commands.UpdateProductProductType;

internal sealed class UpdateProductProductTypeCommandHandler : ICommandHandler<UpdateProductProductTypeCommand>
{
	private readonly IProductRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateProductProductTypeCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateProductProductTypeCommand request, CancellationToken cancellationToken)
	{
		var result = await _repository.UpdateProductTypeAsync(request.ProductId, request.ProductTypeId, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
