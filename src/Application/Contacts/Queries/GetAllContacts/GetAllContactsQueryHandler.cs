using VendorService.Application.Abstractions.Messaging;
using VendorService.Domain.Entities;
using VendorService.Domain.Repositories;
using VendorService.Domain.Shared;

namespace VendorService.Application.Contacts.Queries.GetAllContacts;

internal sealed class GetAllContactsQueryHandler : IQueryHandler<GetAllContactsQuery, IEnumerable<Contact>>
{
	private readonly IContactRepository _contactRepository;

	public GetAllContactsQueryHandler(IContactRepository contactRepository)
	{
		_contactRepository = contactRepository;
	}


	public async Task<Result<IEnumerable<Contact>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
	{
		return await _contactRepository.GetAllAsync(cancellationToken);
	}
}
