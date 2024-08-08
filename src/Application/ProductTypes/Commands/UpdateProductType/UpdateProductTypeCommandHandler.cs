using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.ProductTypes.Commands.UpdateProductType;

internal sealed class UpdateProductTypeCommandHandler : ICommandHandler<UpdateProductTypeCommand>
{
	private readonly IProductTypeRepository _repository;
	private readonly IUnitOfWork _unitOfOWork;

	public UpdateProductTypeCommandHandler(IProductTypeRepository repository, IUnitOfWork unitOfOWork)
	{
		_repository = repository;
		_unitOfOWork = unitOfOWork;
	}

	public async Task<Result> Handle(UpdateProductTypeCommand command, CancellationToken cancellationToken)
	{
		var result = await _repository.UpdateAsync(command.ItemType, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfOWork.SaveChangesAsync(cancellationToken);
		return Result.Success();
	}
}
