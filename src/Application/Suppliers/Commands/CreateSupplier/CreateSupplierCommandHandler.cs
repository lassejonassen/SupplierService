using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;
using SupplierService.Domain.Errors;
using SupplierService.Domain.Repositories;
using SupplierService.Domain.Shared;

namespace SupplierService.Application.Suppliers.Commands.CreateSupplier;

internal sealed class CreateSupplierCommandHandler : ICommandHandler<CreateSupplierCommand, Guid>
{
	private readonly ISupplierRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateSupplierCommandHandler(ISupplierRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
	{
		if (!await _repository.IsNameUnique(request.Name, cancellationToken))
		{
			return Result.Failure<Guid>(DomainErrors.Supplier.NameAlreadyExists);
		}

		if (!await _repository.IsEmailUnique(request.Email, cancellationToken))
		{
			return Result.Failure<Guid>(DomainErrors.Supplier.EmailAlreadyInUse);
		}

		// TODO: Add Email validation.
		// TODO: Add a note of who has created the supplier.


		var supplier = Supplier.Create(
			request.Name,
			request.Street,
			request.City,
			request.PostalCode,
			request.Country,
			request.State,
			request.Email,
			request.Phone,
			request.Notes);


		await _repository.AddAsync(supplier, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return supplier.Id;
	}
}
