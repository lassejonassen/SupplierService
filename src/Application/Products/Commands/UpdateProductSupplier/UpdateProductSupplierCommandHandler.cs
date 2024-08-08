using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Products.Commands.UpdateProductSupplier;

internal sealed class UpdateProductSupplierCommandHandler : ICommandHandler<UpdateProductSupplierCommand>
{
	private readonly IProductRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateProductSupplierCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateProductSupplierCommand request, CancellationToken cancellationToken)
	{
		var result = await _repository.UpdateSupplierAsync(request.ProductId, request.SupplierId, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
