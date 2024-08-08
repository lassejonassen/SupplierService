namespace VendorService.Application.Vendors.Commands.UpdateVendor;

internal sealed class UpdateVendorCommandHandler : ICommandHandler<UpdateVendorCommand>
{
	private readonly IVendorRepository _repository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateVendorCommandHandler(IVendorRepository repository, IUnitOfWork unitOfWork)
	{
		_repository = repository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
	{
		var result = await _repository.UpdateAsync(request.Vendor, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure(result.Error);
		}

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
