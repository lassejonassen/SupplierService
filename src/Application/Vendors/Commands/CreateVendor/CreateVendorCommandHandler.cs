using VendorService.Domain.Errors;
using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;
using VendorService.Application.Abstractions.Messaging;

namespace VendorService.Application.Vendors.Commands.CreateVendor;

internal sealed class CreateVendorCommandHandler : ICommandHandler<CreateVendorCommand, Guid>
{
	private readonly IVendorRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateVendorCommandHandler(IVendorRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
	{
		if (!await _repository.IsNameUnique(request.Name, cancellationToken))
		{
			return Result.Failure<Guid>(DomainErrors.Vendor.NameAlreadyExists);
		}

		if (!await _repository.IsEmailUnique(request.Email, cancellationToken))
		{
			return Result.Failure<Guid>(DomainErrors.Vendor.EmailAlreadyInUse);
		}

		// TODO: Add Email validation.
		// TODO: Add a note of who has created the supplier.


		var supplier = Vendor.Create(
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
