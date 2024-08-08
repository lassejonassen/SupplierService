using SupplierService.Application.Abstractions.Messaging;
using SupplierService.Domain.Entities;
using SupplierService.Domain.Repositories;
using SupplierService.Domain.Shared;

namespace SupplierService.Application.Contacts.Queries.GetContactBySupplierId;

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
