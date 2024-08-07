using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;
using SupplierService.Domain.Errors;
using SupplierService.Domain.Repositories;
using SupplierService.Domain.Shared;

namespace SupplierService.Application.ProductTypes.Commands.CreateProductType;

internal sealed class CreateProductTypeCommandHandler : ICommandHandler<CreateProductTypeCommand, Guid>
{
	private readonly IProductTypeRepository _repository;
	private readonly ISupplierRepository _supplierRepository;
	private readonly IUnitOfWork _unitOfOWork;

	public CreateProductTypeCommandHandler(IProductTypeRepository repository, ISupplierRepository supplierRepository, IUnitOfWork unitOfOWork)
	{
		_repository = repository;
		_supplierRepository = supplierRepository;
		_unitOfOWork = unitOfOWork;
	}

	public async Task<Result<Guid>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
	{
		var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId, cancellationToken);

		if (supplier.IsFailure)
		{
			return Result.Failure<Guid>(DomainErrors.Supplier.NotFound);
		}


		var itemType = new ProductType {
			Id = Guid.NewGuid(),
			CorrelationId = Guid.NewGuid(),
			CreatedAt = DateTimeOffset.Now,
			UpdatedAt = null,
			Name = request.Name,
			Supplier = supplier.Value,
			SupplierId = supplier.Value.Id
		};

		await _repository.AddAsync(itemType, cancellationToken);
		await _unitOfOWork.SaveChangesAsync(cancellationToken);

		return itemType.Id;
	}
}
