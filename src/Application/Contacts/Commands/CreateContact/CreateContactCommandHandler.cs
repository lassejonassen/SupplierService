namespace VendorService.Application.Contacts.Commands.CreateContact;

internal sealed class CreateContactCommandHandler : ICommandHandler<CreateContactCommand, Guid>
{
	private readonly IContactRepository _contactRepository;
	private readonly IVendorRepository _supplierRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateContactCommandHandler(IContactRepository contactRepository, IVendorRepository supplierRepository, IUnitOfWork unitOfWork)
	{
		_contactRepository = contactRepository;
		_supplierRepository = supplierRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<Guid>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
	{
		if (!await _contactRepository.IsEmailUnique(request.Email, cancellationToken))
		{
			return Result.Failure<Guid>(DomainErrors.Contact.EmailAlreadyInUse);
		}

		var supplier = await _supplierRepository.GetByIdAsync(request.SupplierId, cancellationToken);

		if (supplier.IsFailure)
		{
			return Result.Failure<Guid>(DomainErrors.Vendor.NotFound);
		}

		var contact = Contact.Create(
			request.FirstName,
			request.LastName,
			request.Email,
			request.Phone,
			request.Notes,
			supplier.Value);

		await _contactRepository.AddAsync(contact, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return contact.Id;
	}
}
