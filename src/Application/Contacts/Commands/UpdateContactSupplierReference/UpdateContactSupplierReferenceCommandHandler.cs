namespace SupplierService.Application.Contacts.Commands.UpdateContactSupplierReference;

internal sealed class UpdateContactSupplierReferenceCommandHandler : ICommandHandler<UpdateContactSupplierReferenceCommand>
{
	private readonly IContactRepository _contactRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateContactSupplierReferenceCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
	{
		_contactRepository = contactRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateContactSupplierReferenceCommand request, CancellationToken cancellationToken)
	{
		var result = await _contactRepository.UpdateSupplierReferenceAsync(request.ContactId, request.SupplierId, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		return Result.Success();
	}
}
