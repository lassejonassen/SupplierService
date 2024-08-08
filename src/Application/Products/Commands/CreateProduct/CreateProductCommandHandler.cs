using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Products.Commands.CreateProduct;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Guid>
{
	private readonly IProductRepository _productRepository;
	private readonly IProductTypeRepository _productTypeRepository;
	private readonly IVendorRepository _supplierRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateProductCommandHandler(
		IProductRepository productRepository,
		IProductTypeRepository productTypeRepository,
		IVendorRepository supplierRepository,
		IUnitOfWork unitOfWork)
	{
		_productRepository = productRepository;
		_productTypeRepository = productTypeRepository;
		_supplierRepository = supplierRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId, cancellationToken);

		if (supplier.IsFailure)
		{
			return Result.Failure<Guid>(supplier.Error);
		}

		var productType = await _productTypeRepository.GetByIdAsync(request.ProductTypeId, cancellationToken);

		if (productType.IsFailure)
		{
			return Result.Failure<Guid>(productType.Error);
		}

		var product = Product.Create(request.Name, request.Description, request.SKU, productType.Value, supplier.Value);

		var result = await _productRepository.AddAsync(product, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure<Guid>(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);


		return product.Id;
	}
}
