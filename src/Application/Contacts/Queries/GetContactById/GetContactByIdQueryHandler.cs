using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Contacts.Queries.GetContactById;

internal sealed class GetContactByIdQueryHandler : IQueryHandler<GetContactByIdQuery, Contact>
{
	private readonly IContactRepository _repository;

	public GetContactByIdQueryHandler(IContactRepository repository)
	{
		_repository = repository;
	}


	public async Task<Result<Contact>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
	{
		var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

		if (result.IsFailure)
		{
			return Result.Failure<Contact>(result.Error);
		}

		return result.Value;
	}
}
