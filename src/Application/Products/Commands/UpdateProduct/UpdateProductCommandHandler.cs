using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Products.Commands.UpdateProduct;

internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
	private readonly IProductRepository _productRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
	{
		_productRepository = productRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		var result = await _productRepository.UpdateAsync(request.Product, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
