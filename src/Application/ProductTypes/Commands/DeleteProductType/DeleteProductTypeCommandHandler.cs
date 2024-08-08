namespace SupplierService.Application.ProductTypes.Commands.DeleteProductType;

internal sealed class DeleteProductTypeCommandHandler : ICommandHandler<DeleteProductTypeCommand>
{
	private readonly IProductTypeRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteProductTypeCommandHandler(IProductTypeRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(DeleteProductTypeCommand command, CancellationToken cancellationToken)
	{
		var result = await _repository.RemoveAsync(command.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
