using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Repositories;
using SupplierService.Domain.Shared;

namespace SupplierService.Application.Contacts.Commands.DeleteContact;

internal sealed class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand>
{
	private readonly IContactRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteContactCommandHandler(IContactRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
	{
		var contact = await _repository.GetByIdAsync(request.Id, cancellationToken);

		if (contact.IsFailure)
		{
			return Result.Failure(contact.Error);
		}

		var result = await _repository.RemoveAsync(contact.Value.Id, cancellationToken);

		if (result.IsFailure)
		{ 
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync();

		return Result.Success();
	}
}
