namespace VendorService.Application.Contacts.Commands.UpdateContactVendorReference;

internal sealed class UpdateContactVendorReferenceCommandHandler : ICommandHandler<UpdateContactVendorReferenceCommand>
{
	private readonly IContactRepository _contactRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateContactVendorReferenceCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
	{
		_contactRepository = contactRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateContactVendorReferenceCommand request, CancellationToken cancellationToken)
	{
		var result = await _contactRepository.UpdateSupplierReferenceAsync(request.ContactId, request.SupplierId, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		return Result.Success();
	}
}
