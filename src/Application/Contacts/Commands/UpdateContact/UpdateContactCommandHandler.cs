using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Contacts.Commands.UpdateContact;

internal sealed class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand>
{
	private readonly IContactRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
	{
		var result = await _repository.UpdateAsync(request.Contact, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
