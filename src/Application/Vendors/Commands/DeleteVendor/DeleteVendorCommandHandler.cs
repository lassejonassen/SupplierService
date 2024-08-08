using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Vendors.Commands.DeleteVendor;

internal sealed class DeleteVendorCommandHandler : ICommandHandler<DeleteVendorCommand>
{
	private readonly IVendorRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteVendorCommandHandler(IVendorRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(DeleteVendorCommand command, CancellationToken cancellationToken)
	{
		var result = await _repository.RemoveAsync(command.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
