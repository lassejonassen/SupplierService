using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Contacts.Queries.GetContactBySupplierId;

internal sealed class GetContactBySupplierIdQueryHandler : IQueryHandler<GetContactBySupplierIdQuery, IEnumerable<Contact>>
{
	private readonly IContactRepository _repository;

	public GetContactBySupplierIdQueryHandler(IContactRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<IEnumerable<Contact>>> Handle(GetContactBySupplierIdQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetBySupplierIdAsync(request.SupplierId, cancellationToken);
	}
}
