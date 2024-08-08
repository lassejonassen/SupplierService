using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Products.Commands.UpdateProductSKU;

internal sealed class UpdateProductSKUCommandHandler : ICommandHandler<UpdateProductSKUCommand>
{
	private readonly IProductRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateProductSKUCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateProductSKUCommand request, CancellationToken cancellationToken)
	{
		var result = await _repository.UpdateSKUAsync(request.ProductId, request.Sku, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
